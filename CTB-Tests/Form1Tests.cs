using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using CatchTheButton;

namespace CTB_Tests
{
    [TestClass]
    public class Form1Tests
    {
        [TestMethod]
        public void button3_ClickCloseForm()
        {
            Form1 form = new Form1();
            form.Show();

            Button button = (Button)GetControl("button3", form);
            button.PerformClick();

            Assert.IsTrue(form.IsDisposed);
        }

        [TestMethod]
        public void textBox1_TextChanged_UpdateGlobalVariable()
        {
            string newName = "TestName";

            Form1 form = new Form1();
            form.Show();

            TextBox textBox = (TextBox)GetControl("textBox1", form);
            textBox.Text = newName;

            Assert.AreEqual(newName, GlobalVariables.CurrentName);
        }

        private Control GetControl(string name, Form form)
        {
            return form.Controls.Find(name, true)[0];
        }
    }
}
