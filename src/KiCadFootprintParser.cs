using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KiCadPanelAssyFG
{
    public class KiCadFootprintData
    {
        public List<LineF> OutlineSegments;
        public List<PointF> OutlinePolyPoints;
        public bool outlineIsClosedPolygonalChain { private set; get; }

        public KiCadFootprintData()
        {
            OutlineSegments = new List<LineF>();
            OutlinePolyPoints = new List<PointF>();
            outlineIsClosedPolygonalChain = false;
        }

        public KiCadFootprintData(List<LineF> outline)
        {
            OutlineSegments = outline;
            OutlinePolyPoints = new List<PointF>();
            outlineIsClosedPolygonalChain = false;
        }

        public KiCadFootprintData(KiCadFootprintData refData)
        {
            OutlineSegments = new List<LineF>(refData.OutlineSegments);
            OutlinePolyPoints = new List<PointF>(refData.OutlinePolyPoints);
            outlineIsClosedPolygonalChain = refData.outlineIsClosedPolygonalChain;
        }

        public bool TryBuildClosedPolygonalLine()
        {
            if (OutlineSegments.Count > 0)
            {
                outlineIsClosedPolygonalChain = false;

                OutlinePolyPoints.Clear();
                List<LineF> refSegmentsList = new List<LineF>(OutlineSegments);

                // Dictionary of all outline segments where the key is the line's start point and the value is the according endpoint.
                Dictionary<PointF, PointF> SegmentsMap = new Dictionary<PointF, PointF>();
                SegmentsMap.Add(OutlineSegments[0].StartPoint, OutlineSegments[0].EndPoint);

                // Remove first line from the reference list, since it was already added to the map.
                refSegmentsList.RemoveAt(0);

                for (int i = 0; i < OutlineSegments.Count - 1; i++)
                {
                    bool matchFound = false;
                    for (int j = 0; j < refSegmentsList.Count; j++)
                    {
                        if (refSegmentsList[j].StartPoint == SegmentsMap.ElementAt(SegmentsMap.Count - 1).Value)
                        {
                            // Check for triple point
                            if (SegmentsMap.ContainsKey(refSegmentsList[j].StartPoint)) return false;

                            SegmentsMap.Add(refSegmentsList[j].StartPoint, refSegmentsList[j].EndPoint);
                            refSegmentsList.RemoveAt(j);
                            matchFound = true;
                            break;
                        }
                        else if (refSegmentsList[j].EndPoint == SegmentsMap.ElementAt(SegmentsMap.Count - 1).Value)
                        {
                            // Check for triple point
                            if (SegmentsMap.ContainsKey(refSegmentsList[j].EndPoint)) return false;

                            SegmentsMap.Add(refSegmentsList[j].EndPoint, refSegmentsList[j].StartPoint);
                            refSegmentsList.RemoveAt(j);
                            matchFound = true;
                            break;
                        }
                    }

                    if (!matchFound) return false;
                }

                // Check if loop is closed
                if (SegmentsMap.First().Key != SegmentsMap.ElementAt(SegmentsMap.Count - 1).Value) return false;

                OutlinePolyPoints.AddRange(SegmentsMap.Keys);
                outlineIsClosedPolygonalChain = true;

                return true;
            }

            // Outline is empty
            return false;
        }
    }

    public static class KiCadFootprintParser
    {
        public static KiCadFootprintData ParseKiCadFootprint(string fileDir)
        {
            return ParseKiCadFootprint(File.ReadLines(fileDir));
        }

        public static KiCadFootprintData ParseKiCadFootprint(IEnumerable<string> rawData)
        {
            List<string> dataLines = rawData.ToList();

            Dictionary<string, List<Dictionary<string, string>>> structuredFpData = new Dictionary<string, List<Dictionary<string, string>>>();

            for (int i = 0; i < dataLines.Count; i++)
            {
                Match startAdvancedPropertyMatch = Regex.Match(dataLines[i], "\\A\t\\((\\w+)\\Z");

                if (startAdvancedPropertyMatch.Success)
                {
                    string propertyName = startAdvancedPropertyMatch.Groups[1].Value;

                    bool subPropertyEndFound = false;
                    int subPropertyLines = 0;

                    string rawSubProperties = "";

                    // Get sub property lines count
                    for (; (i + subPropertyLines + 1) < dataLines.Count; subPropertyLines++)
                    {
                        if (dataLines[i + subPropertyLines + 1].StartsWith("\t)"))
                        {
                            subPropertyEndFound = true;
                            break;
                        }
                        else
                        {
                            if (subPropertyLines > 0) rawSubProperties += "\n";
                            rawSubProperties += dataLines[i + subPropertyLines + 1];
                        }
                    }

                    if (subPropertyEndFound)
                    {
                        MatchCollection subPropertyMatches = Regex.Matches(rawSubProperties, "^\\t\\t\\(([\\w\"\\. \\-\\(\\)]+)\\)$|^\\t\\t\\(([\\w \\r\\n\\t\\(\\)\\.\\-]+?)\\n\\t\\t\\)$", RegexOptions.Multiline);

                        Dictionary<string, string> subProperties = new Dictionary<string, string>();

                        foreach (Match subPropertyMatch in subPropertyMatches)
                        {
                            if (subPropertyMatch.Groups[1].Success)
                            {
                                // Single line match
                                string[] splitMatch = subPropertyMatch.Groups[1].Value.Replace("\"", "").Split(new char[] { ' ' }, 2);

                                if (!subProperties.ContainsKey(splitMatch[0]))
                                {
                                    subProperties.Add(splitMatch[0], splitMatch[1]);
                                }
                            }
                            else if (subPropertyMatch.Groups[2].Success)
                            {
                                // Multi line match
                                string[] splitMatch = subPropertyMatch.Groups[2].Value.Replace("\t", "").Replace(Environment.NewLine, " ").Replace("\n", " ").Replace("\"", "").Split(new char[] { ' ' }, 2);

                                if (!subProperties.ContainsKey(splitMatch[0]))
                                {
                                    subProperties.Add(splitMatch[0], splitMatch[1]);
                                }
                            }
                        }

                        if (structuredFpData.ContainsKey(propertyName))
                        {
                            structuredFpData[propertyName].Add(subProperties);
                        }
                        else
                        {
                            structuredFpData.Add(propertyName, new List<Dictionary<string, string>>().Append(subProperties).ToList());
                        }
                    }
                    else
                    {
                        throw new InvalidKiCadFootprintException("File ended before property was finished");
                    }

                    // Skip handled lines
                    i += subPropertyLines;
                }
            }

            List<LineF> outlineSegments = new List<LineF>();

            string layerFilter = "F.CrtYd";

            // Check if footprint contains front courtyard lines
            if (structuredFpData.ContainsKey("fp_line"))
            {
                foreach (Dictionary<string, string> line in structuredFpData["fp_line"])
                {
                    // Filter out unimportant layers
                    if (!line["layer"].Contains(layerFilter)) continue;

                    string[] startSplitStr = line["start"].Trim().Split(" ");
                    string[] endSplitStr = line["end"].Trim().Split(" ");

                    outlineSegments.Add(new LineF(new PointF(float.Parse(startSplitStr[0]), float.Parse(startSplitStr[1])), new PointF(float.Parse(endSplitStr[0]), float.Parse(endSplitStr[1]))));
                }
            }

            // Check if footprint contains front courtyard rectangles
            if (structuredFpData.ContainsKey("fp_rect"))
            {
                foreach (Dictionary<string, string> polyLine in structuredFpData["fp_rect"])
                {
                    // Filter out unimportant layers
                    if (!polyLine["layer"].Contains(layerFilter)) continue;

                    string[] startSplitStr = polyLine["start"].Trim().Split(" ");
                    string[] endSplitStr = polyLine["end"].Trim().Split(" ");

                    PointF startPoint = new PointF(float.Parse(startSplitStr[0]), float.Parse(startSplitStr[1]));
                    PointF endPoint = new PointF(float.Parse(endSplitStr[0]), float.Parse(endSplitStr[1]));
                    
                    // Add rectangle to as individual segments
                    outlineSegments.Add(new LineF(new PointF(startPoint.X, startPoint.Y), new PointF(endPoint.X, startPoint.Y)));
                    outlineSegments.Add(new LineF(new PointF(endPoint.X, startPoint.Y), new PointF(endPoint.X, endPoint.Y)));
                    outlineSegments.Add(new LineF(new PointF(endPoint.X, endPoint.Y), new PointF(startPoint.X, endPoint.Y)));
                    outlineSegments.Add(new LineF(new PointF(startPoint.X, endPoint.Y), new PointF(startPoint.X, startPoint.Y)));
                }
            }

            // Check if footprint contains front courtyard polygon lines
            if (structuredFpData.ContainsKey("fp_poly"))
            {
                foreach (Dictionary<string, string> rect in structuredFpData["fp_poly"])
                {
                    // Filter out unimportant layers
                    if (!rect["layer"].Contains(layerFilter)) continue;

                    MatchCollection CoordinateMatches = Regex.Matches(rect["pts"], "\\(xy (-?\\d+.?\\d*) (-?\\d+.?\\d*)\\)");

                    List<PointF> coordinates = new List<PointF>();

                    foreach (Match CoordinateMatch in CoordinateMatches)
                    {
                        // Get all coordinates
                        coordinates.Add(new PointF(float.Parse(CoordinateMatch.Groups[1].Value), float.Parse(CoordinateMatch.Groups[2].Value)));
                    }

                    for (int i = 0; i < coordinates.Count; i++)
                    {
                        // Generate segments
                        outlineSegments.Add(new LineF(coordinates[i], coordinates[(i + 1) % coordinates.Count]));
                    }
                }
            }

            return new KiCadFootprintData(outlineSegments);
        }
    }

    public static class KiCadFootprintUtil
    {
        public static string GetRelativePathFromFootprintName(string name)
        {
            string[] splitName = name.Trim().Split(':');

            if (splitName.Length != 2) throw new ArgumentDataException("Invalid footprint name, ':' (colon) character not found");

            return splitName[0] + ".pretty\\" + splitName[1] + ".kicad_mod";
        }
    }
}
