#region namespaces
using System;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Linq;
#endregion // namespaces

namespace RoomFinishes
{
    internal class RoomData
    {
        public Room room { get; set; }
        public List<Element> elems { get; set; }
        public Dictionary<string, string> finishingFloors { get; set; }
        public Dictionary<string, string> finishingWalls { get; set; }
        public Dictionary<string, string> ceilings { get; set; }
    }

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    class RoomFinder : IExternalCommand
    {
        public ElementId levelId { get; set; } // vai buscar e define o valor de levelId
        public string finishingFloorsAssemblyCode { get; set; } // vai buscar e define o valor de floorsAssemblyCode
        public string finishingWallsAssemblyCode { get; set; } // vai buscar e define o valor de wallsAssemblyCode
        public string ceilingsAssemblyCode { get; set; } // vai buscar e define o valor de ceilingsAssemblyCode

        public string finishingFloorsKeynoteParamName { get; set; } // vai buscar e define o valor de finishingFloorsParamName
        public string finishingWallsKeynoteParamName { get; set; } // vai buscar e define o valor de finishingWallsParamName
        public string ceilingsKeynoteParamName { get; set; } // vai buscar e define o valor de ceilingsParamName

        public string finishingFloorsDescriptionParamName { get; set; } // vai buscar e define o valor de finishingFloorsParamName
        public string finishingWallsDescriptionParamName { get; set; } // vai buscar e define o valor de finishingWallsParamName
        public string ceilingsDescriptionParamName { get; set; } // vai buscar e define o valor de ceilingsParamName

        public virtual Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Calls Modeless Form
            try
            {
                Application.thisApp.ShowForm(commandData.Application);

                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }
        }

        #region MainMethod Method
        // defines the Main Method with 1 argument: ActiveUIDoc
        public void SetRoomFinishingParameters(UIDocument ActiveUIDoc)
        {
            //Active document in Revit application
            Document doc = ActiveUIDoc.Document;

            //Get collection of Rooms in indicated level
            IEnumerable<Element> collector = FindRooms(ActiveUIDoc);

            //List of RoomData
            List<RoomData> roomDataList = new List<RoomData>();

            foreach (Room r in collector)
            {
                #region Retrieving of Room Data
                //List of RoomBoudingElements
                List<Element> roomBoundingElems = new List<Element>();

                // Calculate a room's geometry and find its boundary faces
                SpatialElementGeometryCalculator calculator = new SpatialElementGeometryCalculator(doc);
                SpatialElementGeometryResults results = calculator.CalculateSpatialElementGeometry(r); // compute the room geometry 
                Solid roomSolid = results.GetGeometry(); // get the solid representing the room's geometry

                // Go through the boundary faces to add this element to the list of roomBoundingElems
                foreach (Face face in roomSolid.Faces)
                {
                    IList<SpatialElementBoundarySubface> boundaryFaces = results.GetBoundaryFaceInfo(face);
                    foreach (SpatialElementBoundarySubface boundaryFace in boundaryFaces)
                    {
                        // Get boundary element
                        LinkElementId boundaryElementId = boundaryFace.SpatialBoundaryElement;

                        // Only considering local file room bounding elements
                        ElementId localElementId = boundaryElementId.HostElementId;
                        Element elem = doc.GetElement(localElementId);

                        //Add Room Bounding Element to list
                        roomBoundingElems.Add(elem);
                    }
                }

                //List of all Element Types of the Room Bounding Elements
                List<Element> elemsType = new List<Element>();

                foreach (Element elem in roomBoundingElems)
                {
                    ElementId id = elem.GetTypeId();
                    Element elemType = doc.GetElement(id);
                    elemsType.Add(elemType);
                }

                //List of all unique Element Types of the Room Bounding Elements
                List<Element> elemsTypeDist = elemsType.Distinct(new ElemTypeIdEqualityComparer()).ToList();

                //List of all unique Element Types of the Room Bounding Elements with the Floors Assembly Code indicated
                IEnumerable<Element> finishingFloorsElemsTypes = GetFinishingElemsTypes(elemsTypeDist, finishingFloorsAssemblyCode);
                //Dictionary with Key values and Keynote Texts
                Dictionary<string, string> finishingFloorsKeynote = GetKeynote(finishingFloorsElemsTypes, ActiveUIDoc); //Dictionary<string, string>

                //List of all unique Element Types of the Room Bounding Elements with the Floors Assembly Code indicated
                IEnumerable<Element> finishingWallsElemsTypes = GetFinishingElemsTypes(elemsTypeDist, finishingWallsAssemblyCode);
                //Dictionary with Key values and Keynote Texts
                Dictionary<string, string> finishingWallsKeynote = GetKeynote(finishingWallsElemsTypes, ActiveUIDoc);

                //List of all unique Element Types of the Room Bounding Elements with the Floors Assembly Code indicated
                IEnumerable<Element> ceilingsElemsTypes = GetFinishingElemsTypes(elemsTypeDist, ceilingsAssemblyCode);
                //Dictionary with Key values and Keynote Texts
                Dictionary<string, string> ceilingsKeynote = GetKeynote(ceilingsElemsTypes, ActiveUIDoc);

                #endregion // Retrieving of Room Data

                //new RoomData class per room
                var RD = new RoomData
                {
                    room = r,
                    elems = roomBoundingElems,
                    finishingFloors = finishingFloorsKeynote,
                    finishingWalls = finishingWallsKeynote,
                    ceilings = ceilingsKeynote,
                };

                //Adds Room Data to Room Data List
                roomDataList.Add(RD);
            }

            //Fills Parameters
            FillParameters(roomDataList, doc);
        }
        #endregion //Main Method

        #region FillParameters Method

        public void FillParameters(List<RoomData> roomDataList, Document doc)
        {
            foreach (RoomData roomData in roomDataList)
            {
                Room r = roomData.room;

                Dictionary<string, string> finishingFloorsKeynote = roomData.finishingFloors;
                Dictionary<string, string> finishingWallsKeynote = roomData.finishingWalls;
                Dictionary<string, string> ceilingsKeynote = roomData.ceilings;

                FillKeynoteParameters(r, finishingFloorsKeynote, finishingFloorsKeynoteParamName, finishingFloorsDescriptionParamName, doc);
                FillKeynoteParameters(r, finishingWallsKeynote, finishingWallsKeynoteParamName, finishingWallsDescriptionParamName, doc);
                FillKeynoteParameters(r, ceilingsKeynote, ceilingsKeynoteParamName, ceilingsDescriptionParamName, doc);
            }
        }
        #endregion //FillParameters Method

        #region FillKeynoteParameters Method

        public void FillKeynoteParameters(Room r, Dictionary<string ,string> keynote, string keynoteTextspName, string keyValuespName, Document doc)
        {
            using (Transaction trans = new Transaction(doc, "Change parameters value")) // nova transacao trans do tipo Transaction
            {
                trans.Start();

                Parameter pKeynoteText = r.LookupParameter(keynoteTextspName);
                Parameter pKeyValue = r.LookupParameter(keyValuespName);

                int nKeys = keynote.Keys.Count;
                int nValues = keynote.Values.Count;
                
                if (pKeynoteText != null && pKeyValue != null)
                {
                    if (nKeys >= 1 && nValues >= 1)
                    {
                        SortedDictionary<string, string> keynoteSorted = new SortedDictionary<string, string>(keynote);

                        List<string> keyValueslist = keynoteSorted.Keys.ToList();
                        List<string> keynoteTextslist = keynoteSorted.Values.ToList();

                        foreach (string key in keyValueslist)
                        {
                            string delimiter = " / ";
                            string pKeynoteTextValue = keyValueslist.Aggregate((i, j) => i + delimiter + j);
                            string pKeyValueValue = keynoteTextslist.Aggregate((i, j) => i + delimiter + j);

                            pKeynoteText.Set(pKeynoteTextValue);
                            pKeyValue.Set(pKeyValueValue);
                        }
                    }
                    else
                    {
                        string noValue = "-------";
                        pKeynoteText.Set(noValue);
                        pKeyValue.Set(noValue);
                    }
                }
                trans.Commit();
            }
        }

        #endregion //FillKeynoteParameters Method

        #region GetKeynote Method

        public Dictionary<string, string> GetKeynote(IEnumerable<Element> roomelemsTypes, UIDocument ActiveUIDocument)
        {
            KeyBasedTreeEntries kbte = GetKeynoteEntries(ActiveUIDocument);
            
            IEnumerable<KeyBasedTreeEntry> keyValues;

            Dictionary<string, string> elemsKeynote = new Dictionary<string, string>();

            foreach (Element e in roomelemsTypes)
            {
                Parameter p = e.get_Parameter(BuiltInParameter.KEYNOTE_PARAM);

                if (p != null)
                {
                    string pValue = GetParameterValue(p);

                    keyValues = kbte.Where(k => k.Key.Equals(pValue));
                        
                    foreach(KeynoteEntry k in keyValues)
                    {
                        string keynoteText = k.KeynoteText;
                        string keyValue = k.Key;

                        elemsKeynote.Add(keyValue, keynoteText);
                    }
                }
            }
            return elemsKeynote;
        }

        #endregion //GetKeynote

        #region Get Finishing Elements Types Method

        public IEnumerable<Element> GetFinishingElemsTypes(List<Element> elemsTypeDist, string AssemblyCode)
        {
            //List of all unique Element Types of the Room Bounding Elements with the Assembly Code
            IEnumerable<Element> finishingElems =
                elemsTypeDist.Where(a => a.get_Parameter(BuiltInParameter.UNIFORMAT_CODE).AsString() == AssemblyCode);

            return finishingElems;
        }
        #endregion //Get Elements Type Method

        #region FindRooms Method

        public IEnumerable<Element> FindRooms(UIDocument ActiveUIDocument) // define o metodo FindRooms com dois argumentos levelId e ActiveUIDocument
        {
            Document doc = ActiveUIDocument.Document; // doc define o documento ativo na aplicacao

            levelId = FillRoomFinishesParameters.comboBoxLevels.Text;

            IEnumerable<Element> collector =
                new FilteredElementCollector(doc)
                  .WhereElementIsNotElementType()
                  .OfClass(typeof(SpatialElement))
                  .Where(e => e.GetType() == typeof(Room))
                  .Where(e => e.LevelId.Equals(levelId))
                  .Cast<Room>(); // Lista enumerada de cada Room presente no level indicado

            return collector;
        }

        #endregion //FindRooms Method

        #region GetKeynoteTable Method
        public KeyBasedTreeEntries GetKeynoteEntries(UIDocument ActiveUIDocument)
        {
            Document doc = ActiveUIDocument.Document; // doc define o documento ativo na aplicacao

            KeynoteTable Kt = KeynoteTable.GetKeynoteTable(doc);

            KeyBasedTreeEntries kbte = Kt.GetKeyBasedTreeEntries();

            return kbte;
        }

        #endregion //GetKeynoteTable Method

        #region GetParameterValue and RealString Method

        public static string GetParameterValue(Parameter param)
        {
            string s;
            switch (param.StorageType)
            {
                case StorageType.Double:
                    //
                    // the internal database unit for all lengths is feet.
                    // for instance, if a given room perimeter is returned as
                    // 102.36 as a double and the display unit is millimeters,
                    // then the length will be displayed as
                    // peri = 102.36220472440
                    // peri * 12 * 25.4
                    // 31200 mm
                    //
                    //s = param.AsValueString(); // value seen by user, in display units
                    //s = param.AsDouble().ToString(); // if not using not using LabUtils.RealString()
                    s = RealString(param.AsDouble()); // raw database value in internal units, e.g. feet
                    break;

                case StorageType.Integer:
                    s = param.AsInteger().ToString();
                    break;

                case StorageType.String:
                    s = param.AsString();
                    break;

                case StorageType.ElementId:
                    s = param.AsElementId().IntegerValue.ToString();
                    break;

                case StorageType.None:
                    s = "?NONE?";
                    break;

                default:
                    s = "?ELSE?";
                    break;
            }
            return s;
        }

        public static string RealString(double a)
        {
            return a.ToString("0.##");
        }

        #endregion SetValue, GetParameterValue and RealString Method

        #region ElemTypeIdEqualityComparer Class

        private class ElemTypeIdEqualityComparer : IEqualityComparer<Element>
        {
            public bool Equals(Element x, Element y)
            {
                //Compares Element Types by Id
                return x.Id == y.Id;
            }

            public int GetHashCode(Element obj)
            {
                return obj.Id.IntegerValue;
            }
        }

        #endregion //ElemTypeIdEqualityComparer Class
    }
}

