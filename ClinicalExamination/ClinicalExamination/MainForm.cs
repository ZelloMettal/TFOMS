using System;
using System.IO;
using System.Windows.Forms;
using ClinicalExamination.Classes;

namespace ClinicalExamination
{
    public partial class MainForm : Form
    {
        static string XML_file_patch = $@"{Directory.GetCurrentDirectory()}\INPUT\XML_Test.xml";
        static string XSD_file_patch = $@"{Directory.GetCurrentDirectory()}\INPUT\XSD_Test.xsd";
        static private string connectionString = $"Server=WIN-UFO1CIKLBV0;DataBase=Clinical Examination;Trusted_Connection=True;TrustServerCertificate=True";
        public MainForm()
        {
            InitializeComponent();
        }

        private void button_Run_Click(object sender, System.EventArgs e)
        {
            ValidatorXML validator = new ValidatorXML();
            richTextBox_Result.Text = "ЗАПУСК ПРОЦЕДУРЫ НА УРОВНЕ ПРИЛОЖЕНИЯ\nПроверка валидации файла";
            try 
            {
                if (validator.Validator(XML_file_patch, XSD_file_patch))
                {
                    richTextBox_Result.Text += $"\nВалидация прошла успешно!";
                }
                else 
                {
                    richTextBox_Result.Text += $"\nВалидация НЕ прошла успешно! \n{validator.Error}\nОперация отменена!";
                    return;
                }            
            }
            catch(Exception ex)
            {
                richTextBox_Result.Text += $"\nОшибка валидатора: {ex.Message}";
                return;
            }
            
            XMLDeserialize deserialize = new XMLDeserialize();
            ZL_LIST xml = deserialize.XmlDeserializer(XML_file_patch);
            
            richTextBox_Result.Text += "\nПроверка соответствия полей PERS/KOL";
            
            try
            { 
                EVENT evn = (EVENT)xml.Items[1];
                if (evn.KOL_M + evn.KOL_W == evn.PERS.Length)
                    richTextBox_Result.Text += $"\nПараметр KOL_M = {evn.KOL_M} \nПараметр KOL_W = {evn.KOL_W} \nОбщее количество строк PERS = {evn.PERS.Length}\nПроверка полей успешно прошла";
                else
                { 
                    richTextBox_Result.Text += $"\nПараметр KOL_M = {evn.KOL_M} \nПараметр KOL_W = {evn.KOL_W} \nОбщее количество строк PERS = {evn.PERS.Length}\nПроверка полей НЕ успешно прошла\nОперация отменена";
                    return;
                }    
            }
            catch (Exception ex) 
            {
                richTextBox_Result.Text += $"\nОшибка проверки: {ex.Message}";
                return;
            }

            richTextBox_Result.Text += $"\nЗАПУСК ПРОЦЕДУРЫ НА УРОВНЕ БД\nПроверка валидации";
            DBWorker DB = new DBWorker(connectionString);
            string answer = string.Empty;
            try
            {
                answer = DB.ExecStorageProcedure("CheckValidation", 300);
                if (answer.Contains("-1"))
                { 
                    richTextBox_Result.Text += $"\n{answer.Remove(0,2)}\nОперация прервана!";
                    return;
                }
                else
                    richTextBox_Result.Text += $"\n{answer.Remove(0,2)}\nОперация выполнена!";
            }
            catch (Exception ex)
            {
                richTextBox_Result.Text += $"\nОшибка валидатора: {ex.Message}";
                return;
            }

            richTextBox_Result.Text += "\nПроверка соответствия полей PERS/KOL";
            try
            {
                answer = DB.ExecStorageProcedure("ChechCountPers", 300);
                if (answer.Contains("-1"))
                {
                    richTextBox_Result.Text += $"\n{answer.Remove(0,2)}\n Операция прервана!";
                    return;
                }
                else
                    richTextBox_Result.Text += $"\n{answer.Remove(0,2)}\n Операция выполнена!";
            }
            catch (Exception ex)
            {
                richTextBox_Result.Text += $"\nОшибка проверки: {ex.Message}";
                return;
            }

            richTextBox_Result.Text += "\nДобавление записей в БД";
            try
            {
                answer = DB.ExecStorageProcedure("InsertXMLtoDB");
                richTextBox_Result.Text += $"\nДанные успешно добавлены\nДобавлено строк {answer}";

            }
            catch (Exception ex)
            {
                richTextBox_Result.Text += $"\nОшибка добавления: {ex.Message}";
                return;
            }
        }
    }
}
