using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace studentInformationSystem
{
    public partial class Form2 : Form
    {
        Form1 frm1 = new Form1();
        int selectedRow;
        string gender = " ";
        byte[] img;

        public Form2()
        {
            InitializeComponent();
            // Count the number of column
            dataGridView_studentInfo.ColumnCount = 33;
            dataGridView_studentInfo.Columns[0].Name = "Student Number";
            dataGridView_studentInfo.Columns[1].Name = "first name";
            dataGridView_studentInfo.Columns[2].Name = "Middle name";
            dataGridView_studentInfo.Columns[3].Name = "Last name";
            dataGridView_studentInfo.Columns[4].Name = "Suffix";
            dataGridView_studentInfo.Columns[5].Name = "Age";
            dataGridView_studentInfo.Columns[6].Name = "Gender";
            dataGridView_studentInfo.Columns[7].Name = "Birthdate";
            dataGridView_studentInfo.Columns[8].Name = "Birth place";
            dataGridView_studentInfo.Columns[9].Name = "Contact number";
            dataGridView_studentInfo.Columns[10].Name = "Current address";
            dataGridView_studentInfo.Columns[11].Name = "Religion";
            dataGridView_studentInfo.Columns[12].Name = "Citizenship";
            dataGridView_studentInfo.Columns[13].Name = "Institutional Email";
            dataGridView_studentInfo.Columns[14].Name = "Standing";
            dataGridView_studentInfo.Columns[15].Name = "Year level";
            dataGridView_studentInfo.Columns[16].Name = "Program of Study";
            dataGridView_studentInfo.Columns[17].Name = "Last school attended";
            dataGridView_studentInfo.Columns[18].Name = "C++";
            dataGridView_studentInfo.Columns[19].Name = "C#";
            dataGridView_studentInfo.Columns[20].Name = "PHP";
            dataGridView_studentInfo.Columns[21].Name = "JAVA";
            dataGridView_studentInfo.Columns[22].Name = "VB.NET";
            dataGridView_studentInfo.Columns[23].Name = "PYTHON";
            dataGridView_studentInfo.Columns[24].Name = "Mother's maiden name";
            dataGridView_studentInfo.Columns[25].Name = "Mother's Contact Number";
            dataGridView_studentInfo.Columns[26].Name = "Mother's Occupation";
            dataGridView_studentInfo.Columns[27].Name = "Mother's Salary";
            dataGridView_studentInfo.Columns[28].Name = "Father's name";
            dataGridView_studentInfo.Columns[29].Name = "Father's contact number";
            dataGridView_studentInfo.Columns[30].Name = "Father's Occupation";
            dataGridView_studentInfo.Columns[31].Name = "Father's Salary";
            dataGridView_studentInfo.Columns[32].Name = "Image";
           
        }
        

        // method for radiobuttons/gender
        public void radioButtons()
        {
            
            if (radioButton_male.Checked)
                gender = "Male";
            else if (radioButton_female.Checked)
                gender = "Female";
        }

        
        public void picBox()
        {
            // Save image from PictureBox into MemoryStream object
            MemoryStream ms = new MemoryStream();
            pictureBox_student.Image.Save(ms, pictureBox_student.Image.RawFormat);
            img = ms.ToArray();
        }



        private void btn_save_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Do you want to save this record?", "Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // validation 
                if (txt_studentNum.Text == "" || txt_firstName.Text == "" || txt_middleName.Text ==  "" ||
                    txt_lastName.Text == "" || numericUpDown_age.Value == 15 || txt_birthPlace.Text == ""
                    || txt_contactNum.Text == "" || txt_currentAdd.Text == "" || txt_religion.Text == "" ||
                    txt_citizenship.Text == "" || txt_Iemail.Text == "" || comboBox_standing.SelectedItem == null ||
                    comboBox_yearLevel.SelectedItem == null || comboBox_programOfStudy.SelectedItem == null || txt_lastSchoolAtt.Text == ""
                    || txt_motherName.Text == "" || txt_motherNum.Text == "" || txt_motherOccu.Text == "" ||
                    comboBox_motherSalary.SelectedItem == null || txt_fatherName.Text == "" || txt_fatherNum.Text == "" ||
                    txt_fatherOccu.Text == "" || comboBox_fatherSalary.SelectedItem == null || pictureBox_student.Image == null)
                {
                    MessageBox.Show("Please fill in the required information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    radioButtons();
                    picBox();

                    // Read the Value in each textbox, image, etc. and add row to data grid view
                    dataGridView_studentInfo.Rows.Add(txt_studentNum.Text, txt_firstName.Text,
                        txt_middleName.Text, txt_lastName.Text, txt_suffix.Text, numericUpDown_age.Value,
                        gender, dateTimePicker_birthDate.Value, txt_birthPlace.Text, txt_contactNum.Text, txt_currentAdd.Text,
                        txt_religion.Text, txt_citizenship.Text, txt_Iemail.Text, comboBox_standing.SelectedItem,
                        comboBox_yearLevel.SelectedItem, comboBox_programOfStudy.SelectedItem, txt_lastSchoolAtt.Text,
                        checkBox_cPlusPlus.Checked, checkBox_cSharp.Checked, checkBox_php.Checked, checkBox_java.Checked,
                        checkBox_vbnet.Checked, checkBox_python.Checked, txt_motherName.Text, txt_motherNum.Text, txt_motherOccu.Text,
                        comboBox_motherSalary.SelectedItem, txt_fatherName.Text, txt_fatherNum.Text, txt_fatherOccu.Text,
                        comboBox_fatherSalary.SelectedItem,
                        pictureBox_student.Image);


                    clearAll();
                }
                
            }
            else
            {
                MessageBox.Show("Record not saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            // Allows users to browse the folders of their computer and select one img
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Filter = "Choose image (*.jpg; *.png; *.gif;) | *.jpg; *.png; *.gif;";

            if (openfile.ShowDialog() == DialogResult.OK)
                pictureBox_student.Image = Image.FromFile(openfile.FileName);
        }

        private void txt_studentNum_Validating(object sender, CancelEventArgs e)
        {
            // if else statement to know if the textbox is empty
            if (string.IsNullOrWhiteSpace(txt_studentNum.Text))
            {
                // if empty the errorprovider will show next to textbox
                e.Cancel = true;
                txt_studentNum.Focus();
                errorProvider1.SetError(txt_studentNum, "Should not blank");
            }
            else
            {
                // if not empty nothing will show
                e.Cancel = false;
                errorProvider1.SetError(txt_studentNum, "");
            }
        }

        private void txt_firstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_firstName.Text))
            {
                e.Cancel = true;
                txt_firstName.Focus();
                errorProvider2.SetError(txt_firstName, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(txt_firstName, "");
            }
        }

        private void txt_middleName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_middleName.Text))
            {
                e.Cancel = true;
                txt_firstName.Focus();
                errorProvider3.SetError(txt_middleName, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(txt_middleName, "");
            }
        }

        private void txt_lastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_lastName.Text))
            {
                e.Cancel = true;
                txt_firstName.Focus();
                errorProvider4.SetError(txt_lastName, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider4.SetError(txt_lastName, "");
            }
        }

        private void txt_birthPlace_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_birthPlace.Text))
            {
                e.Cancel = true;
                txt_firstName.Focus();
                errorProvider5.SetError(txt_birthPlace, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider5.SetError(txt_birthPlace, "");
            }
        }

        private void txt_contactNum_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_contactNum.Text))
            {
                e.Cancel = true;
                txt_firstName.Focus();
                errorProvider6.SetError(txt_contactNum, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider6.SetError(txt_contactNum, "");
            }
        }

        private void txt_currentAdd_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_currentAdd.Text))
            {
                e.Cancel = true;
                txt_firstName.Focus();
                errorProvider7.SetError(txt_currentAdd, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider7.SetError(txt_currentAdd, "");
            }
        }

        private void txt_religion_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_religion.Text))
            {
                e.Cancel = true;
                txt_firstName.Focus();
                errorProvider8.SetError(txt_religion, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider8.SetError(txt_religion, "");
            }
        }

        private void txt_citizenship_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_citizenship.Text))
            {
                e.Cancel = true;
                txt_firstName.Focus();
                errorProvider9.SetError(txt_citizenship, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider9.SetError(txt_citizenship, "");
            }
        }

        private void txt_Iemail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Iemail.Text))
            {
                e.Cancel = true;
                txt_firstName.Focus();
                errorProvider10.SetError(txt_Iemail, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider10.SetError(txt_Iemail, "");
            }
        }

        private void comboBox_standing_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox_standing.Text))
            {
                e.Cancel = true;
                txt_firstName.Focus();
                errorProvider11.SetError(comboBox_standing, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider11.SetError(comboBox_standing, "");
            }
        }

        private void comboBox_yearLevel_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox_yearLevel.Text))
            {
                e.Cancel = true;
                txt_firstName.Focus();
                errorProvider12.SetError(comboBox_yearLevel, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider12.SetError(comboBox_yearLevel, "");
            }
        }

        private void comboBox_programOfStudy_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox_programOfStudy.Text))
            {
                e.Cancel = true;
                txt_firstName.Focus();
                errorProvider13.SetError(comboBox_programOfStudy, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider13.SetError(comboBox_programOfStudy, "");
            }
        }

        private void txt_lastSchoolAtt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_lastSchoolAtt.Text))
            {
                e.Cancel = true;
                txt_firstName.Focus();
                errorProvider14.SetError(txt_lastSchoolAtt, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider14.SetError(txt_lastSchoolAtt, "");
            }
        }

        private void txt_motherName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_motherName.Text))
            {
                e.Cancel = true;
                txt_firstName.Focus();
                errorProvider15.SetError(txt_motherName, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider15.SetError(txt_motherName, "");
            }
        }

        private void txt_motherNum_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_motherNum.Text))
            {
                e.Cancel = true;
                txt_firstName.Focus();
                errorProvider16.SetError(txt_motherNum, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider16.SetError(txt_motherNum, "");
            }
        }

        private void txt_motherOccu_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_motherOccu.Text))
            {
                e.Cancel = true;
                txt_firstName.Focus();
                errorProvider17.SetError(txt_motherOccu, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider17.SetError(txt_motherOccu, "");
            }
        }

        private void comboBox_motherSalary_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox_motherSalary.Text))
            {
                e.Cancel = true;
                txt_firstName.Focus();
                errorProvider18.SetError(comboBox_motherSalary, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider18.SetError(comboBox_motherSalary, "");
            }
        }

        private void txt_fatherName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_fatherName.Text))
            {
                e.Cancel = true;
                txt_firstName.Focus();
                errorProvider19.SetError(txt_fatherName, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider19.SetError(txt_fatherName, "");
            }
        }

        private void txt_fatherNum_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_fatherNum.Text))
            {
                e.Cancel = true;
                txt_firstName.Focus();
                errorProvider20.SetError(txt_fatherNum, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider20.SetError(txt_fatherNum, "");
            }
        }

        private void txt_fatherOccu_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_fatherOccu.Text))
            {
                e.Cancel = true;
                txt_firstName.Focus();
                errorProvider21.SetError(txt_fatherOccu, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider21.SetError(txt_fatherOccu, "");
            }
        }

        private void comboBox_fatherSalary_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox_fatherSalary.Text))
            {
                e.Cancel = true;
                txt_firstName.Focus();
                errorProvider22.SetError(comboBox_fatherSalary, "Should not blank");
            }
            else
            {
                e.Cancel = false;
                errorProvider22.SetError(comboBox_fatherSalary, "");
            }
        }

        private void txt_studentNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows the user to use space & backspace
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Space &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                // show if the user use other key in keyboard
                MessageBox.Show("Please Enter Numbers only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_firstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows the user to use space & backspace
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                // show if the user use other key in keyboard
                MessageBox.Show("Please Enter Letters only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_middleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows the user to use space & backspace
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                // show if the user use other key in keyboard
                MessageBox.Show("Please Enter Letters only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_lastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows the user to use space & backspace
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                // show if the user use other key in keyboard
                MessageBox.Show("Please Enter Letters only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_suffix_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows the user to use space & backspace
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                // show if the user use other key in keyboard
                MessageBox.Show("Please Enter Letters only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_birthPlace_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows the user to use space & backspace
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                // show if the user use other key in keyboard
                MessageBox.Show("Please Enter Letters only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_contactNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows the user to use space & backspace
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Space &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                // show if the user use other key in keyboard
                MessageBox.Show("Please Enter Numbers only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_currentAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows the user to use space & backspace
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Space &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                // show if the user use other key in keyboard
                MessageBox.Show("Please Enter Numbers & Letters only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_religion_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows the user to use space & backspace
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                // show if the user use other key in keyboard
                MessageBox.Show("Please Enter Letters only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_citizenship_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows the user to use space & backspace
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                // show if the user use other key in keyboard
                MessageBox.Show("Please Enter Letters only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_lastSchoolAtt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows the user to use space & backspace
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                // show if the user use other key in keyboard
                MessageBox.Show("Please Enter Letters only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_motherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows the user to use space & backspace
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                // show if the user use other key in keyboard
                MessageBox.Show("Please Enter Letters only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_motherNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows the user to use space & backspace
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Space &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                // show if the user use other key in keyboard
                MessageBox.Show("Please Enter Numbers only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_motherOccu_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows the user to use space & backspace
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                // show if the user use other key in keyboard
                MessageBox.Show("Please Enter Letters only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_fatherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows the user to use space & backspace
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                // show if the user use other key in keyboard
                MessageBox.Show("Please Enter Letters only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_fatherNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows the user to use space & backspace
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Space &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                // show if the user use other key in keyboard
                MessageBox.Show("Please Enter Numbers only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_fatherOccu_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows the user to use space & backspace
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                // show if the user use other key in keyboard
                MessageBox.Show("Please Enter Letters only", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to logout?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // hide the form 2 and show the form 1
                this.Hide();
                Form1 frm1 = new Form1();
                frm1.Show();
            }
        }

        
        public void clearAll()
        {
            txt_studentNum.Clear();
            txt_firstName.Clear();
            txt_middleName.Clear();
            txt_lastName.Clear();
            txt_suffix.Clear();
            numericUpDown_age.Value = 15;
            radioButton_male.Checked = false;
            radioButton_female.Checked = false;
            dateTimePicker_birthDate.ResetText();
            txt_birthPlace.Clear();
            txt_contactNum.Clear();
            txt_currentAdd.Clear();
            txt_religion.Clear();
            txt_citizenship.Clear();
            txt_Iemail.Clear();
            comboBox_standing.SelectedItem = null;
            comboBox_yearLevel.SelectedItem = null;
            comboBox_programOfStudy.SelectedItem = null;
            txt_lastSchoolAtt.Clear();
            checkBox_cPlusPlus.Checked = false;
            checkBox_cSharp.Checked = false;
            checkBox_java.Checked = false;
            checkBox_php.Checked = false;
            checkBox_python.Checked = false;
            checkBox_vbnet.Checked = false;
            txt_motherName.Clear();
            txt_motherNum.Clear();
            txt_motherOccu.Clear();
            comboBox_motherSalary.SelectedItem = null;
            txt_fatherName.Clear();
            txt_fatherNum.Clear();
            txt_fatherOccu.Clear();
            comboBox_fatherSalary.SelectedItem = null;
            pictureBox_student.Image = null;
        }

        private void btn_clearAll_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to clear all?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clearAll();
            }
            
        }

        private void dataGridView_studentInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            // if else statement, if the user want to update the record 
            if (MessageBox.Show("Do you want to update this record?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                radioButtons();
                // if yes, the selected row will update
                DataGridViewRow row2 = dataGridView_studentInfo.Rows[selectedRow];
                row2.Cells[0].Value = txt_studentNum.Text;
                row2.Cells[1].Value = txt_firstName.Text;
                row2.Cells[2].Value = txt_middleName.Text;
                row2.Cells[3].Value = txt_lastName.Text;
                row2.Cells[4].Value = txt_suffix.Text;
                row2.Cells[5].Value = numericUpDown_age.Value;
                row2.Cells[6].Value = gender;
                row2.Cells[7].Value = dateTimePicker_birthDate.Value;
                row2.Cells[8].Value = txt_birthPlace.Text;
                row2.Cells[9].Value = txt_contactNum.Text;
                row2.Cells[10].Value = txt_currentAdd.Text;
                row2.Cells[11].Value = txt_religion.Text;
                row2.Cells[12].Value = txt_citizenship.Text;
                row2.Cells[13].Value = txt_Iemail.Text;
                row2.Cells[14].Value = comboBox_standing.SelectedItem;
                row2.Cells[15].Value = comboBox_yearLevel.SelectedItem;
                row2.Cells[16].Value = comboBox_programOfStudy.SelectedItem;
                row2.Cells[17].Value = txt_lastSchoolAtt.Text;
                row2.Cells[18].Value = checkBox_cPlusPlus.Checked;
                row2.Cells[19].Value = checkBox_cSharp.Checked;
                row2.Cells[20].Value = checkBox_php.Checked;
                row2.Cells[21].Value = checkBox_java.Checked;
                row2.Cells[22].Value = checkBox_vbnet.Checked;
                row2.Cells[23].Value = checkBox_python.Checked;
                row2.Cells[24].Value = txt_motherName.Text;
                row2.Cells[25].Value = txt_motherNum.Text;
                row2.Cells[26].Value = txt_motherOccu.Text;
                row2.Cells[27].Value = comboBox_motherSalary.SelectedItem;
                row2.Cells[28].Value = txt_fatherName.Text;
                row2.Cells[29].Value = txt_fatherNum.Text;
                row2.Cells[30].Value = txt_fatherOccu.Text;
                row2.Cells[31].Value = comboBox_fatherSalary.SelectedItem;
                row2.Cells[32].Value = pictureBox_student.Image;
                
            } else
            {
                // if no, this message box will show
                MessageBox.Show("Record not updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            // if else statement, if the user want to delete the record
            if (MessageBox.Show("Do you want to delete this record?", "Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // if yes, delete the choosen row
                selectedRow = dataGridView_studentInfo.CurrentCell.RowIndex;
                dataGridView_studentInfo.Rows.RemoveAt(selectedRow);

                clearAll();
            }
            else
            {
                // if no, this messagebox will show
                MessageBox.Show("Record not deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView_studentInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow row = dataGridView_studentInfo.Rows[selectedRow];
            txt_studentNum.Text = row.Cells[0].Value.ToString();
            txt_firstName.Text = row.Cells[1].Value.ToString();
            txt_middleName.Text = row.Cells[2].Value.ToString();
            txt_lastName.Text = row.Cells[3].Value.ToString();
            txt_suffix.Text = row.Cells[4].Value.ToString();
            numericUpDown_age.Value = (decimal)row.Cells[5].Value;
            //gender = row.Cells[6].Value.ToString();
            dateTimePicker_birthDate.Value = (DateTime)row.Cells[7].Value;
            txt_birthPlace.Text = row.Cells[8].Value.ToString();
            txt_contactNum.Text = row.Cells[9].Value.ToString();
            txt_currentAdd.Text = row.Cells[10].Value.ToString();
            txt_religion.Text = row.Cells[11].Value.ToString();
            txt_citizenship.Text = row.Cells[12].Value.ToString();
            txt_Iemail.Text = row.Cells[13].Value.ToString();
            comboBox_standing.SelectedItem = row.Cells[14].Value;
            comboBox_yearLevel.SelectedItem = row.Cells[15].Value;
            comboBox_programOfStudy.SelectedItem = row.Cells[16].Value;
            txt_lastSchoolAtt.Text = row.Cells[17].Value.ToString();
            checkBox_cPlusPlus.Checked = (bool)row.Cells[18].Value;
            checkBox_cSharp.Checked = (bool)row.Cells[19].Value;
            checkBox_php.Checked = (bool)row.Cells[20].Value;
            checkBox_java.Checked = (bool)row.Cells[21].Value;
            checkBox_vbnet.Checked = (bool)row.Cells[22].Value;
            checkBox_python.Checked = (bool)row.Cells[23].Value;
            txt_motherName.Text = row.Cells[24].Value.ToString();
            txt_motherNum.Text = row.Cells[25].Value.ToString();
            txt_motherOccu.Text = row.Cells[26].Value.ToString();
            comboBox_motherSalary.SelectedItem = row.Cells[27].Value;
            txt_fatherName.Text = row.Cells[28].Value.ToString();
            txt_fatherNum.Text = row.Cells[29].Value.ToString();
            txt_fatherOccu.Text = row.Cells[30].Value.ToString();
            comboBox_fatherSalary.SelectedItem = row.Cells[31].Value;
            pictureBox_student.Image = (Image)row.Cells[32].Value;

        }
    }
}