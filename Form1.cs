using CATMat;
using CATRma;
using INFITF;
using MECMOD;
using SPATypeLib;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

namespace AssignWeight
{
    public partial class Form_AssignWeight : Form
    {
        private readonly CatConnect _catConnect = new CatConnect();

        private INFITF.Application myCATIA;

        public Form_AssignWeight()
        {
            InitializeComponent();
        }

        private void Button_Assign_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Weight.Text))
            {
                MessageBox.Show("Enter a weight value");
                return;
            }
            else
            {
                SetMaterial(Convert.ToDouble(textBox_Weight.Text));
            }
        }

        private void Form_AssignWeight_Load(object sender, EventArgs e)
        {
            try
            {
                myCATIA = (INFITF.Application)Marshal.GetActiveObject("CATIA.Application");
            }
            catch
            {
            }
            
            if (myCATIA == null)
            {
                MessageBox.Show("There is no CATIA!!!");
                this.Close();
            }
            Console.WriteLine("Checked. Connected");
        }

        private void SetMaterial(double weight)
        {
            if (myCATIA != null)
            {
                string sDocPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Catalog.CATMaterial");

                //string sDocPath = myCATIA.SystemService.Environ("CATDocView");

                if (!System.IO.File.Exists(sDocPath))
                {
                    MessageBox.Show("No material catalog found...");
                }

                Document oMaterialDocument = myCATIA.Documents.Read(sDocPath);
                MaterialDocument soMaterialDocument = (MaterialDocument)oMaterialDocument;
                MaterialFamilies cFamilies = soMaterialDocument.Families;
                MaterialFamily oMaterialFamily = cFamilies.Item(2);
                Materials cMaterials = oMaterialFamily.Materials;
                Material oMaterial = cMaterials.Item(1);

                if (!_catConnect.IsDocumentLoaded())
                {
                    MessageBox.Show("Please open a CATIA Part Document if you want to add a material");
                    return;
                }
               
                PartDocument myPartDoc = myCATIA.ActiveDocument as PartDocument;

                Selection oSelection = myPartDoc.Selection;
                if (myPartDoc != null)
                {
                    object[] color = new object[] { 110, 1, 1 };
                    Part oPart = myPartDoc.Part;
                    Body oBody = oPart.MainBody;
                    MaterialManager manager = (MaterialManager)oPart.GetItem("CATMatManagerVBExt");
                    
                    manager.GetMaterialOnPart(oPart, out Material materialOnPart);
                    manager.GetMaterialOnBody(oBody, out Material materialOnBody);

                    if (materialOnPart != null)
                    {
                        oSelection.Add(materialOnPart);
                        oSelection.Delete();
                    }
                    else
                    {
                    }
                    
                    Bodies cBodies = oPart.Bodies;
                    foreach ( Body body in cBodies )
                    {
                        manager.GetMaterialOnBody(body, out Material tmpMaterial);
                        if (tmpMaterial != null)
                        {
                            oSelection.Add(tmpMaterial);
                            oSelection.Delete();
                        }
                    }
                    
                    Reference refBody = oPart.CreateReferenceFromObject(oBody);
                    Reference refPart = oPart.CreateReferenceFromObject(oPart);
                    SPAWorkbench mySPA = (SPAWorkbench)myCATIA.ActiveDocument.GetWorkbench("SPAWorkbench");
                    Measurable elementBody = mySPA.GetMeasurable(refBody);
                    Measurable elementPart = mySPA.GetMeasurable(refPart);
                    double finalVolume = 0;
                    double volumeBody;
                    double volumePart = 0;

                    try
                    {
                        volumeBody = elementBody.Volume;
                        finalVolume = volumeBody;
                    }
                    catch
                    {
                        volumeBody = 0;
                    }

                    try
                    {
                        volumePart = elementPart.Volume;
                        finalVolume = volumePart;
                    }
                    catch
                    {
                    }

                    double density = weight / finalVolume;
                    AnalysisMaterial oAnalysis = oMaterial.AnalysisMaterial;
                    RenderingMaterial rendering = oMaterial.RenderingMaterial;
                    oMaterial.set_Name("Variable");
                    oAnalysis.PutValue("SAMDensity", density.ToString());
                    rendering.AmbientCoefficient = 0.4f;
                    rendering.DiffuseCoefficient = 0.4f;
                    rendering.ReflectivityCoefficient = 0.15;
                    rendering.PutAmbientColor(color);
                    rendering.PutDiffuseColor(color);
                    rendering.PutSpecularColor(color);

                    if (volumeBody != 0 && volumeBody == volumePart)
                    {
                        manager.ApplyMaterialOnBody(oBody, oMaterial, 2);
                    }
                    else
                    {
                        manager.ApplyMaterialOnPart(oPart, oMaterial, 2);
                    }
                    oPart.Update();
                    oMaterialDocument.Close();
                }
            }
        }
    }
}
