using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KiCadPanelAssyFG
{
    internal class KiCadFootprintParser
    {
        public static KiCadFootprintData ParseKiCadFootprint(string fileDir)
        {
            return ParseKiCadFootprint(File.ReadLines(fileDir));
        }

        public static KiCadFootprintData ParseKiCadFootprint(IEnumerable<string> rawData)
        {
            List<LineF> outlineSegments = new List<LineF>();
            List<string> dataLines = rawData.ToList();

            for (int i = 0; i < dataLines.Count; i++)
            {
                if (dataLines[i].Trim().StartsWith("(fp_line") && dataLines.Skip(i).Take(5).Any(l => l.Contains("(layer \"F.CrtYd\")")))
                {
                    PointF startPoint = new PointF();
                    PointF endPoint = new PointF();

                    bool startFound = false;
                    bool endFound = false;

                    for (int j = i; j < i + 5 && j < dataLines.Count; j++)
                    {
                        Match startMatch = Regex.Match(dataLines[j], "\\(start (-?\\d+\\.\\d*) (-?\\d+\\.\\d*)\\)");
                        Match endMatch = Regex.Match(dataLines[j + 1], "\\(end (-?\\d+\\.\\d*) (-?\\d+\\.\\d*)\\)");

                        if (startMatch.Success)
                        {
                            startPoint = new PointF
                            {
                                X = float.Parse(startMatch.Groups[1].Value),
                                Y = float.Parse(startMatch.Groups[2].Value)
                            };
                            startFound = true;
                        }
                        if (endMatch.Success)
                        {
                            startPoint = new PointF
                            {
                                X = float.Parse(endMatch.Groups[1].Value),
                                Y = float.Parse(endMatch.Groups[2].Value)
                            };
                            endFound = true;
                        }
                        if (startFound && endFound)
                        {
                            outlineSegments.Add(new LineF(startPoint, endPoint));
                            // Skip handled data lines
                            i = j;
                        }
                    }
                }
            }

            KiCadFootprintData footprintData = new KiCadFootprintData();
            footprintData.TryBuildClosedPolygonalLine();

            return footprintData;
        }
    }

    internal class KiCadFootprintData
    {
        public List<LineF> OutlineSegments;
        public List<PointF> OutlinePolyPoints;
        public bool outlineIsClosedPolygonalChain { private set; get; }

        public KiCadFootprintData()
        {
            OutlineSegments = new List<LineF>();
            outlineIsClosedPolygonalChain = false;
        }

        public KiCadFootprintData(List<LineF> outline)
        {
            OutlineSegments = outline;
            outlineIsClosedPolygonalChain = false;
        }

        public bool TryBuildClosedPolygonalLine()
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
                    if (refSegmentsList[i].StartPoint == SegmentsMap.ElementAt(SegmentsMap.Count - 1).Value)
                    {
                        // Check for triple point
                        if (SegmentsMap.ContainsKey(refSegmentsList[i].StartPoint)) return false;

                        SegmentsMap.Add(refSegmentsList[i].StartPoint, refSegmentsList[i].EndPoint);
                        refSegmentsList.RemoveAt(j);
                        matchFound = true;
                        break;
                    }
                    else if (refSegmentsList[i].EndPoint == SegmentsMap.ElementAt(SegmentsMap.Count - 1).Value)
                    {
                        // Check for triple point
                        if (SegmentsMap.ContainsKey(refSegmentsList[i].EndPoint)) return false;

                        SegmentsMap.Add(refSegmentsList[i].EndPoint, refSegmentsList[i].StartPoint);
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
    }
}
