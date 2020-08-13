#region namespaces
using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.ComponentModel;
#endregion // namespaces

namespace RoomFinishes
{
    public partial class FillRoomFinishesParameters : System.Windows.Forms.Form // ambiguidade: invocacao da Class Form de SWF e nao de Revit.DB
    {
        // In this sample, the dialog owns the handler and the event objects,
        // but it is not a requirement. They may as well be static properties
        // of the application.

        private RequestHandler m_Handler;
        private ExternalEvent m_ExEvent;

        //Variables
        UIDocument uidoc; // define uidoc como do tipo UIDocument

        RoomFinder accessRF = new RoomFinder(); // nova instancia accessRF do tipo RoomFinder

        Dictionary<string, ElementId> levels = new Dictionary<string, ElementId>();

        string levelName = null;

        //Dialog instantiation
        public FillRoomFinishesParameters(ExternalEvent exEvent, RequestHandler handler, UIApplication uiapp) // define o metodo FillRoomFinishesParameters com um argumento commandData do tipo ExternalCommandData
        {
            Document doc = uiapp.ActiveUIDocument.Document; // doc define o documento ativo na aplicacao
            uidoc = uiapp.ActiveUIDocument; // define uidoc como a propriedade ActiveUIDocument de app

            //Get Levels for comboBoxLevels
            levels = GetLevels(uidoc);
            //List of levels names
            List<string> levelNames = new List<string>(levels.Keys);

            //GetRoom Project Parameters Data
            List<RoomProjectParametersData> projectParameters = GetRoomProjectParametersData(doc);

            InitializeComponent();

            m_Handler = handler;
            m_ExEvent = exEvent;

            comboBoxLevels.Enabled = true;

            foreach (System.Windows.Forms.TextBox textBox in Controls.OfType<System.Windows.Forms.TextBox>())
            {
                textBox.Enabled = true;
            }

            #region comboBoxLevels

            comboBoxLevels.Items.Insert(0, "Select Level");
            comboBoxLevels.SelectedItem = 0;
            comboBoxLevels.Text = "Select Level";

            foreach (string i in levelNames)
            {
                comboBoxLevels.Items.AddRange(new object[] { i });
            }

            #endregion //comboBoxLevels

            #region Assembly Codes

            #region listBoxAssemblyCodes

            //Get Key Values from loaded Keynote
            KeyBasedTreeEntries kbte = accessRF.GetKeynoteEntries(uidoc);

            foreach (KeyBasedTreeEntry k in kbte)
            {
                string keyValue = k.Key;
                listBoxAssemblyCodes.Items.AddRange(new object[] { keyValue });
            }

            #endregion //listBoxAssemblyCodes

            #region textBoxes Assembly Codes

            textBoxFFAC.ReadOnly = true;
            textBoxFWAC.ReadOnly = true;
            textBoxCAC.ReadOnly = true;

            #endregion //textBoxes Assembly Codes

            #endregion //Assembly Codes

            #region textBoxes Room Parameters

            textBoxFFK.ReadOnly = true;
            textBoxFFD.ReadOnly = true;
            textBoxFWK.ReadOnly = true;
            textBoxFWD.ReadOnly = true;
            textBoxCK.ReadOnly = true;
            textBoxCD.ReadOnly = true;

            foreach (RoomProjectParametersData p in projectParameters)
            {
                string pName = p.Name;
                listBoxKeynotes.Items.AddRange(new object[] { pName });
            }

            #endregion //textBoxes Room Parameters
        }

        #region Data holding class
        // This class contains information discovered 
        // about a (shared or non-shared) project parameter 
        class RoomProjectParametersData
        {
            public Definition Definition = null;
            public ElementBinding Binding = null;
            public string Name = null;// Needed because accsessing the Definition later may produce an error.
            public Category category = null;
            public ParameterType type;
        }
        #endregion // Data holding class

        #region GetRoomProjectParametersData Method
        static List<RoomProjectParametersData> GetRoomProjectParametersData(Document doc)
        {
            // Following good SOA practices, first validate incoming parameters
            if (doc == null)
            {
                throw new ArgumentNullException("doc");
            }

            if (doc.IsFamilyDocument)
            {
                throw new Exception("This plugin cannot be run on a family document.");
            }

            List<RoomProjectParametersData> result
              = new List<RoomProjectParametersData>();

            BindingMap map = doc.ParameterBindings;
            DefinitionBindingMapIterator it
              = map.ForwardIterator();
            it.Reset();
            while (it.MoveNext())
            {
                RoomProjectParametersData newProjectParameterData
                  = new RoomProjectParametersData();

                newProjectParameterData.Binding = it.Current
                    as ElementBinding;

                Category roomCategory = Category.GetCategory(doc, BuiltInCategory.OST_Rooms);

                IEnumerable<Category> catSet = newProjectParameterData.Binding.Categories.Cast<Category>();

                if (catSet.Any(c => c.Id.Equals(roomCategory.Id)) && it.Key.ParameterType == ParameterType.Text)
                {
                    newProjectParameterData.category = roomCategory;
                    newProjectParameterData.Definition = it.Key;
                    newProjectParameterData.Name = it.Key.Name;
                    newProjectParameterData.type = it.Key.ParameterType;

                    result.Add(newProjectParameterData);
                }
            }
            return result;
        }
        #endregion //GetRoomProjectParametersData Method

        #region GetLevels Method
        public Dictionary<string, ElementId> GetLevels(UIDocument ActiveUIDocument) // define o metodo GetLevels com um argumento ActiveUIDocument
        {
            Dictionary<string, ElementId> levels = new Dictionary<string, ElementId>();
            Document doc = ActiveUIDocument.Document; // doc define o documento ativo na aplicacao

            IEnumerable<Element> collectorR = new FilteredElementCollector(doc)
                .WhereElementIsNotElementType()
                .OfClass(typeof(Level));

            foreach (Element e in collectorR)
            {
                string name = e.Name;
                ElementId levelId = e.Id;
                levels.Add(name, levelId);
            }
            return levels;
        }
        #endregion //GetLevels Method

        #region Form Items

        private void FillRoomFinishesParameters_Load(object sender, EventArgs e)
        {
            // Turn off validation when a control loses focus. This will be inherited by child
            // controls on the form, enabling us to validate the entire form when the 
            // button is clicked instead of one control at a time.
            AutoValidate = AutoValidate.Disable;
            //Add event handlers
            comboBoxLevels.CausesValidation = true;
            comboBoxLevels.Validating += new CancelEventHandler(comboBoxLevels_Validating);
            foreach (System.Windows.Forms.TextBox textBox in Controls.OfType<System.Windows.Forms.TextBox>())
            {
                textBox.CausesValidation = true;
                textBox.Validating += new CancelEventHandler(TextBox_Validating);
            }
            //Add child to controls
            Controls.Add(comboBoxLevels);
            Controls.Add(textBoxFFAC);
            //Add event handler
            buttonRun.Click += new EventHandler(buttonRun_Click);
        }

        #region Level
        private void labelLevels_Click(object sender, EventArgs e)
        {

        }
        private void comboBoxLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxLevels.DropDownStyle = ComboBoxStyle.DropDownList; //Prevents manual input
            levelName = comboBoxLevels.Text; // define levelName como o texto inserido na comboBoxLevels
            if (levelName != "Select Level")
            accessRF.levelId = levels[levelName]; // define levelId com a Id do levelName inserido em comboBoxLevels
        }
        private void comboBoxLevels_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxLevels.Text) ||
                string.IsNullOrWhiteSpace(comboBoxLevels.Text) ||
                comboBoxLevels.Text == "Select Level")
            {
                //Cancel the event and select the comboBox to be corrected by the user
                e.Cancel = true;
                comboBoxLevels.Select(0, comboBoxLevels.Text.Length);
                //Set the Error Provider error with the text to display
                errorProvider1.SetError(comboBoxLevels, "Please select a level!");
            }
        }
        private void comboBoxLevels_Validated(object sender, CancelEventArgs e)
        {
            //If all conditions have been met, clear the ErrorProvider of errors
            e.Cancel = false;
            errorProvider1.SetError(comboBoxLevels, null);
            
        }
        #endregion //Level

        #region Assembly Codes
        //Available Assembly Codes label
        private void labelAvailableAssemblyCodes_Click(object sender, EventArgs e)
        {

        }
        //AssemblyCode listBox
        private void listBoxAssemblyCodes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region Finishing Floors Assembly Code
        //Finishing Floors Assembly Code label
        private void labelFFAC_Click(object sender, EventArgs e)
        {

        }
        //indexFFAC
        int indexFFAC;
        //Remove from textBoxFFAC button
        private void buttonRemFFAC_Click(object sender, EventArgs e)
        {
            RemParam(textBoxFFAC, listBoxAssemblyCodes, indexFFAC);
        }
        //Add to textBoxFFAC button
        private void buttonAddFFAC_Click(object sender, EventArgs e)
        {
            indexFFAC = AddParamGetIndex(textBoxFFAC, listBoxAssemblyCodes, indexFFAC);
        }

        //Set finishingFloorsAssemblyCode
        private void textBoxFFAC_TextChanged(object sender, EventArgs e)
        {
            accessRF.finishingFloorsAssemblyCode = textBoxFFAC.Text; // define finishingFloorsKeynoteParamName como o texto inserido na textBoxFFAC
        }

        //textBoxFFAC validation method
        private void textBoxFFAC_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFFAC.Text) ||
                string.IsNullOrWhiteSpace(textBoxFFAC.Text))
            {
                //Cancel the event and select the text to be corrected by the user
                e.Cancel = true;
                textBoxFFAC.Select(0, textBoxFFAC.Text.Length);

                //Set the Error Provider error with the text to display
                errorProvider1.SetError(textBoxFFAC, "Please provide the Finishing Floors Assembly Code!");
            }
        }
        //textBoxFFAC validated method
        private void textBoxFFAC_Validated(object sender, CancelEventArgs e)
        {
            //If all conditions have been met, clear the ErrorProvider of errors
            e.Cancel = false;
            errorProvider1.SetError(textBoxFFAC, null);
            
        }
        #endregion //Finishing Floors Assembly Code

        #region Finishing Walls Assembly Code
        //Finishing Walls Assembly Code label
        private void labelFWAC_Click(object sender, EventArgs e)
        {

        }
        //indexFWAC
        int indexFWAC;
        //Remove from textBoxFWAC button
        private void buttonRemFWAC_Click(object sender, EventArgs e)
        {
            RemParam(textBoxFWAC, listBoxAssemblyCodes, indexFWAC);
        }
        //Add to textBoxFFAC button
        private void buttonAddFWAC_Click(object sender, EventArgs e)
        {
            indexFWAC = AddParamGetIndex(textBoxFWAC, listBoxAssemblyCodes, indexFWAC);
        }
        //Set finishingWallsAssemblyCode
        private void textBoxFWAC_TextChanged(object sender, EventArgs e)
        {
            accessRF.finishingWallsAssemblyCode = textBoxFWAC.Text; // define finishingWallsAssemblyCode como o texto inserido na textBoxFWAC
        }
        #endregion //Finishing Walls Assembly Code

        #region Ceilings Assembly Code
        //Ceilings Assembly Code label
        private void labelCAC_Click(object sender, EventArgs e)
        {

        }
        //indexCAC
        int indexCAC;
        //Remove from textBoxCAC button
        private void buttonAddCAC_Click(object sender, EventArgs e)
        {
            RemParam(textBoxCAC, listBoxAssemblyCodes, indexCAC);
        }
        //Add from textBoxCAC button
        private void buttonRemCAC_Click(object sender, EventArgs e)
        {
            indexCAC = AddParamGetIndex(textBoxCAC, listBoxAssemblyCodes, indexCAC);
        }
        //Set ceilngsAssemblyCode
        private void textBoxCAC_TextChanged(object sender, EventArgs e)
        {
            accessRF.ceilingsAssemblyCode = textBoxCAC.Text; // define ceilingsAssemblyCode como o texto inserido na textBoxFWAC
        }

        #endregion //Ceilings Walls Assembly Code

        #endregion //Assembly Codes

        #region Keynotes

        //Available Parameters label
        private void labelAvailableParameters_Click(object sender, EventArgs e)
        {

        }
        //Keynotes listBox
        private void listBoxKeynotes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region Finishing Floors Keynote Parameter
        //Finishing Floors Keynote Parameter label
        private void labelFFK_Click(object sender, EventArgs e)
        {

        }
        //indexFFK
        int indexFFK;
        //Remove from textBoxFFK button
        private void buttonRemFFK_Click(object sender, EventArgs e)
        {
            RemParam(textBoxFFK, listBoxKeynotes, indexFFK);
        }
        //Add to textBoxFFK button
        private void buttonAddFFK_Click(object sender, EventArgs e)
        {
            indexFFK = AddParamGetIndex(textBoxFFK, listBoxKeynotes, indexFFK);
        }
        //Set finishingFloorsKeynoteParamName
        private void textBoxFFK_TextChanged(object sender, EventArgs e)
        {
            accessRF.finishingFloorsKeynoteParamName = textBoxFFK.Text; // define finishingFloorsKeynoteParamName como o texto inserido na textBoxFFK
        }

        #endregion //Finishing Floors Keynote Parameter

        #region Finishing Floors Description Parameter
        //Finishing Floors Description Parameter label
        private void labelFFD_Click(object sender, EventArgs e)
        {

        }
        //indexFFD
        int indexFFD;
        //Remove from textBoxFFD button
        private void buttonRemFFD_Click(object sender, EventArgs e)
        {
            RemParam(textBoxFFD, listBoxKeynotes, indexFFD);
        }
        //Add to textBoxFFD button
        private void buttonAddFFD_Click(object sender, EventArgs e)
        {
            indexFFD = AddParamGetIndex(textBoxFFD, listBoxKeynotes, indexFFD);
        }
        //Set finishinFloorsDescriptionParamName   
        private void textBoxFFD_TextChanged(object sender, EventArgs e)
        {
            accessRF.finishingFloorsDescriptionParamName = textBoxFFD.Text; // define finishingFloorsDescriptionParamName como o texto inserido na textBoxFFD
        }
        #endregion //Finishing Floors Description Parameter

        #region Finishing Walls Keynote Parameter
        //Finishing Walls Keynote Parameter label
        private void labelFWK_Click(object sender, EventArgs e)
        {

        }
        //indexFFK
        int indexFWK;
        //Remove from textBoxFWK button
        private void buttonRemFWK_Click(object sender, EventArgs e)
        {
            RemParam(textBoxFWK, listBoxKeynotes, indexFWK);
        }
        //Add to textBoxFWK button
        private void buttonAddFWK_Click(object sender, EventArgs e)
        {
            indexFWK = AddParamGetIndex(textBoxFWK, listBoxKeynotes, indexFWK);
        }
        //Set finishingWallsKeynoteParamName  
        private void textBoxFWK_TextChanged(object sender, EventArgs e)
        {
            accessRF.finishingWallsKeynoteParamName = textBoxFWK.Text; // define finishingWallsKeynoteParamName como o texto inserido na textBoxFWK
        }
        #endregion //Finishing Walls Keynote Parameter

        #region Finishing Walls Description Parameter
        //Finishing Walls Description Parameter label
        private void labelFWD_Click(object sender, EventArgs e)
        {

        }
        //indexFWD
        int indexFWD;
        //Remove from textBoxFWK button
        private void buttonRemFWD_Click(object sender, EventArgs e)
        {
            RemParam(textBoxFWD, listBoxKeynotes, indexFWD);
        }
        //Add to textBoxFWK button
        private void buttonAddFWD_Click(object sender, EventArgs e)
        {
            indexFWD = AddParamGetIndex(textBoxFWD, listBoxKeynotes, indexFWD);
        }
        //Set finishingWallsKeynoteParamName 
        private void textBoxFWD_TextChanged(object sender, EventArgs e)
        {
            accessRF.finishingWallsDescriptionParamName = textBoxFWD.Text; // define finishingWallsDescriptionParamName como o texto inserido na textBoxFWD
        }

        #endregion //Finishing Walls Description Parameter

        #region Ceilings Keynote Parameter
        //Ceilings Keynote Parameter label
        private void labelCK_Click(object sender, EventArgs e)
        {

        }
        //indexCK
        int indexCK;
        //Remove from textBoxCK button
        private void buttonRemCK_Click(object sender, EventArgs e)
        {
            RemParam(textBoxCK, listBoxKeynotes, indexCK);
        }
        //Add to textBoxCK button
        private void buttonAddCK_Click(object sender, EventArgs e)
        {
            indexCK = AddParamGetIndex(textBoxCK, listBoxKeynotes, indexCK);
        }
        //Set ceilingsKeynoteParamName 
        private void textBoxCK_TextChanged(object sender, EventArgs e)
        {
            accessRF.ceilingsKeynoteParamName = textBoxCK.Text; // define ceilingsKeynoteParamName como o texto inserido na textBoxCK
        }

        #endregion //Ceilings Keynote Parameter

        #region Ceilings Description Parameter
        //Ceilings Description Parameter label
        private void labelCD_Click(object sender, EventArgs e)
        {

        }
        //indexCD
        int indexCD;
        //Remove from textBoxCD button
        private void buttonRemCD_Click(object sender, EventArgs e)
        {
            RemParam(textBoxCD, listBoxKeynotes, indexCD);
        }
        //Add to textBoxCD button
        private void buttonAddCD_Click(object sender, EventArgs e)
        {
            indexCD = AddParamGetIndex(textBoxCD, listBoxKeynotes, indexCD);
        }
        //Set ceilingsDescriptionParamName 
        private void textBoxCD_TextChanged(object sender, EventArgs e)
        {
            accessRF.ceilingsDescriptionParamName = textBoxCD.Text; // define ceilingsDescriptionParamName como o texto inserido na textBoxCD
        }
        #endregion //Ceilings Description Parameter

        #endregion //Keynotes

        #region Add and Rem Parameters Methods

        private int AddParamGetIndex(System.Windows.Forms.TextBox textBox, ListBox listBox, int index)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text) == false && string.IsNullOrEmpty(textBox.Text) == false)
            {
                listBox.Items.Insert(index, textBox.Text);
                textBox.ResetText();
            }
            int newindex = listBox.SelectedIndex;
            textBox.Text = listBox.GetItemText(listBox.SelectedItem);
            listBox.Items.Remove(textBox.Text);

            return newindex;
        }

        private void RemParam(System.Windows.Forms.TextBox textBox, ListBox listBox, int index)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text) == false && string.IsNullOrEmpty(textBox.Text) == false)
            {
                listBox.Items.Insert(index, textBox.Text);
                textBox.ResetText();
            }
        }

        #endregion Add and Rem Parameters Methods

        #region Validation

        //textBoxFFAC validation method
        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;

                if (string.IsNullOrEmpty(textBox.Text) ||
                string.IsNullOrWhiteSpace(textBox.Text))
                {
                    //Cancel the event and select the text to be corrected by the user
                    e.Cancel = true;
                    textBox.Select(0, textBox.Text.Length);

                    //Set the Error Provider error with the text to display
                    errorProvider1.SetError(textBox, "Please provide the " + textBox.AccessibleDescription + "!");
                }
        }
        //textBoxFFAC validated method
        private void textBox_Validated(System.Windows.Forms.TextBox textBox, object sender, CancelEventArgs e)
        {
            //If all conditions have been met, clear the ErrorProvider of errors
            e.Cancel = false;
            errorProvider1.SetError(textBox, null);
        }

        #endregion //Validation

        #region Run

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                timer1.Start();

                //desabilita o botao Run enquanto a tarefa e executada
                buttonRun.Enabled = false;
                //bgWorkerIndeterminada.RunWorkerAsync();

                //define a progressBar para Marquee
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.MarqueeAnimationSpeed = 5;

                //informa que a tarefa esta a ser executada
                labelPercentage.Text = "Processing...";

                //CALLS MAIN METHOD
                MakeRequest(RequestId.FillParameters);
                progressBar1.MarqueeAnimationSpeed = 0;
                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = 100;
                labelPercentage.Text = progressBar1.Value.ToString() + "% Run was successful";

                buttonRun.Enabled = true;
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        private void labelPercentage_Click(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        #endregion //Run

        #endregion //Form Items

        #region Form Events

        // Form closed event handler
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // we own both the event and the handler
            // we should dispose it before we are closed
            m_ExEvent.Dispose();
            m_ExEvent = null;
            m_Handler = null;

            // do not forget to call the base class
            base.OnFormClosed(e);
        }

        //   Control enabler / disabler 
        private void EnableCommands(bool status)
        {
            foreach (System.Windows.Forms.Control ctrl in Controls)
            {
                ctrl.Enabled = status;
            }
            if (!status)
            {
                this.buttonExit.Enabled = true;
            }
        }

        //A private helper method to make a request
        //and put the dialog to sleep at the same time.

        //    It is expected that the process which executes the request 
        //   (the Idling helper in this particular case) will also
        //   wake the dialog up after finishing the execution.

        private void MakeRequest(RequestId request)
        {
            m_Handler.Request.Make(request);
            m_ExEvent.Raise();
            DozeOff();
        }

        //DozeOff -> disable all controls (but the Exit button)
        private void DozeOff()
        {
            EnableCommands(false);
        }

        //WakeUp -> enable all controls
        public void WakeUp()
        {
            EnableCommands(true);
        }

        //Exit - closing the dialog
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }


        #endregion //Form Events
    }
}
