using System;

namespace ClinicalExamination.Classes
{
    [SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ZL_LIST
    {
        private object[] items;

        [System.Xml.Serialization.XmlElementAttribute("EVENT", typeof(EVENT), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("ZGLV", typeof(ZGLV), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public object[] Items
        {
            get {return items;}
            set {items = value;}
        }
    }

    [SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class EVENT
    {
        private string disp;
        private int kol_m;
        private int kol_w;
        private PERS[] pers;

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DISP
        {
            get {return disp;}
            set {disp = value;}
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int KOL_M
        {
            get {return kol_m;}
            set {kol_m = value;}
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int KOL_W
        {
            get {return kol_w;}
            set {kol_w = value;}
        }

        [System.Xml.Serialization.XmlElementAttribute("PERS", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PERS[] PERS
        {
            get {return pers;}
            set {pers = value;}        
        }
    }

    [SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class PERS
    {
        private int n_zap;
        private string id_pac;
        private short w;
        private DateTime dr;
        private string smo;
        private short vpolis;
        private string npolis;
        private string spolis;
        private short quarter;
        private short month;
        private string lpu1;
        private string depth;
        private string ss_doc;
        private string ss_doc_d;
        private short prvs_d;
        private string ds_d;
        private short place_d;
        private string id_tfoms;
        private string comment;
        private int id_event;

        private CONTACTS[] contacts;

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int N_ZAP
        {
            get {return n_zap;}
            set {n_zap = value;}
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ID_PAC
        {
            get {return id_pac;}
            set {id_pac = value;}
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public short W
        {
            get {return w;}
            set {w = value;}
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DateTime DR
        {
            get {return dr;}
            set {dr = value;}
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SMO
        {
            get {return smo;}
            set {smo = value;}
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public short VPOLIS
        {
            get {return vpolis;}
            set {vpolis = value;}
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SPOLIS
        {
            get { return spolis; }
            set { spolis = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string NPOLIS
        {
            get {return npolis;}
            set {npolis = value;}
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public short QUARTER
        {
            get {return quarter;}
            set {quarter = value;}
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public short MONTH
        {
            get { return month; }
            set { month = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LPU1
        {
            get {return lpu1;}
            set {lpu1 = value;}
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DEPTH
        {
            get {return depth;}
            set {depth = value;}
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SS_DOC
        {
            get {return ss_doc;}
            set {ss_doc = value;}
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SS_DOC_D
        {
            get { return ss_doc_d; }
            set { ss_doc_d = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public short PRVS_D
        {
            get {return prvs_d;}
            set {prvs_d = value;}
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DS_D
        {
            get {return ds_d;}
            set {ds_d = value;}
        }


        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public short PLACE_D
        {
            get { return place_d; }
            set { place_d = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ID_TFOMS
        {
            get { return id_tfoms; }
            set { id_tfoms = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string COMMENT
        {
            get { return comment; }
            set { comment = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute("CONTACTS", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CONTACTS[] CONTACTS
        {
            get {return contacts;}
            set {contacts = value;}
        }
    }

    [SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CONTACTS
    {
        private int pers_id;
        private string phone_f;
        private string phone_m;
        private string email;
        private string address;

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int PERS_ID
        {
            get {return pers_id;}
            set {pers_id = value;}
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PHONE_F
        {
            get {return phone_f;}
            set {phone_f = value;}
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PHONE_M
        {
            get { return phone_m; }
            set { phone_m = value; }
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string EMAIL
        {
            get {return email;}
            set {email = value;}
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ADDRESS
        {
            get {return address;}
            set {address = value;}
        }
    }

    [SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ZGLV
    {
        private string version;
        private DateTime date;
        private string filename;
        private short year;
        private string code_mo;

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string VERSION
        {
            get {return version;}
            set {version = value;}
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DateTime DATE
        {
            get {return date;}
            set {date = value;}
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string FILENAME
        {
            get { return filename;}
            set {filename = value;}
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public short YEAR
        {
            get {return year;}
            set {year = value;}
        }

        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CODE_MO
        {
            get {return code_mo;}
            set {code_mo = value;}
        }
    }
}
