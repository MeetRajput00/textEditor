namespace notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String filePath = "C:\\Users\\Meet Rajput\\Documents";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            filePath = openFileDialog1.FileName;
            String line,txt="";
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(filePath);
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    txt += line + "\n";
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception excep)
            {
                Console.WriteLine("Exception: " + excep.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            richTextBox1.Text = txt;
        }
        Boolean saved = false;
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            if (!saved)
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(ofd.FileName, richTextBox1.Text);
                }
            }
            else
            {
                File.WriteAllText(ofd.FileName, richTextBox1.Text);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(ofd.FileName, richTextBox1.Text);
            }
        }

        private void printToolStripMenuItem_Click(object sender, System.Drawing.Printing.PrintPageEventArgs ev)
        {
            StringReader myReader = new StringReader(richTextBox1.Text);
            float linesPerPage = 0;
            float yPosition = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;
            Font printFont = this.richTextBox1.Font;
            SolidBrush myBrush = new SolidBrush(Color.Black);
            // Work out the number of lines per page, using the MarginBounds.  
            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);
            // Iterate over the string using the StringReader, printing each line.  
            while (count < linesPerPage && ((line = myReader.ReadLine()) != null))
            {
                // calculate the next line position based on the height of the font according to the printing device  
                yPosition = topMargin + (count * printFont.GetHeight(ev.Graphics));
                // draw the next line in the rich edit control  
                ev.Graphics.DrawString(line, printFont, myBrush, leftMargin, yPosition, new StringFormat());
                count++;
            }
            // If there are more lines, print another page.  
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
            myBrush.Dispose();
        }
    }
}