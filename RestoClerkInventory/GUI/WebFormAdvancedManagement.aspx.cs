using RestoClerkInventory.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace RestoClerkInventory.GUI
{
    public partial class WebFormAdvancedManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Threshold newThreshold = new Threshold();
            newThreshold = newThreshold.GetThresholdByManagerId(((User)Session["Manager"]).UserId);
            List<Threshold> listOfThresholds = newThreshold.GetAllThresholds();
            if (newThreshold != null)
            {
                if (newThreshold.ModeId == 1)
                {
                    toggleSettings.Checked = true;
                    TextBoxThresholdForOrder.Text = Convert.ToString(newThreshold.ThresholdNumber);
                }
                else
                {
                    toggleSettings.Checked = false;
                }
                TextBoxThresholdForAlarm.Text = Convert.ToString(newThreshold.ThresholdAlarm);

            }
        }


        protected void ButtonThresholdAlarm_Click(object sender, EventArgs e)
        {
            if (toggleSettings.Checked)
            {
                Threshold newThreshold = new Threshold();
                newThreshold = newThreshold.GetThresholdByManagerId(((User)Session["Manager"]).UserId);
                List<Threshold> listOfThresholds = newThreshold.GetAllThresholds();
                if (newThreshold == null)
                {
                    newThreshold = new Threshold();
                    newThreshold.ThresholdId = listOfThresholds.Max(threshold => threshold.ThresholdId) + 1;
                    newThreshold.ModeId = 1;
                    newThreshold.ManagerId = ((User)Session["Manager"]).UserId;
                    if (string.IsNullOrEmpty(TextBoxThresholdForOrder.Text))
                    {
                        MessageBox.Show("Missing Threshold Number", "Warning!!!");
                        return;
                    }
                    if (string.IsNullOrEmpty(TextBoxThresholdForAlarm.Text))
                    {
                        MessageBox.Show("Missing Threshold Alarm", "Warning!!!");
                        return;
                    }
                    newThreshold.ThresholdNumber = Convert.ToInt32(TextBoxThresholdForOrder.Text);
                    newThreshold.ThresholdAlarm = Convert.ToInt32(TextBoxThresholdForAlarm.Text);
                    newThreshold.InsertThreshold(newThreshold);
                }
                else
                {
                    newThreshold.ModeId = 1;
                    if (string.IsNullOrEmpty(TextBoxThresholdForOrder.Text))
                    {
                        MessageBox.Show("Missing Threshold Number", "Warning!!!");
                        return;
                    }
                    if (string.IsNullOrEmpty(TextBoxThresholdForAlarm.Text))
                    {
                        MessageBox.Show("Missing Threshold Alarm", "Warning!!!");
                        return;
                    }

                    newThreshold.ThresholdNumber = Convert.ToInt32(TextBoxThresholdForOrder.Text);
                    newThreshold.ThresholdAlarm = Convert.ToInt32(TextBoxThresholdForAlarm.Text);
                    newThreshold.UpdateThreshold(newThreshold);
                }
            }
            else
            {
                Threshold newThreshold = new Threshold();
                newThreshold = newThreshold.GetThresholdByManagerId(((User)Session["Manager"]).UserId);
                List<Threshold> listOfThresholds = newThreshold.GetAllThresholds();
                if (newThreshold == null)
                {
                    newThreshold = new Threshold();
                    newThreshold.ThresholdId = listOfThresholds.Max(threshold => threshold.ThresholdId) + 1;
                    newThreshold.ModeId = 2;
                    newThreshold.ManagerId = ((User)Session["Manager"]).UserId;
                    if (string.IsNullOrEmpty(TextBoxThresholdForAlarm.Text))
                    {
                        MessageBox.Show("Missing Threshold Alarm", "Warning!!!");
                        return;
                    }
                    newThreshold.ThresholdNumber = -1;
                    newThreshold.ThresholdAlarm = Convert.ToInt32(TextBoxThresholdForAlarm.Text);
                    newThreshold.InsertThreshold(newThreshold);
                }
                else
                {
                    newThreshold.ModeId = 2;
                    if (string.IsNullOrEmpty(TextBoxThresholdForAlarm.Text))
                    {
                        MessageBox.Show("Missing Threshold Alarm", "Warning!!!");
                        return;
                    }
                    newThreshold.ThresholdNumber = -1;
                    newThreshold.ThresholdAlarm = Convert.ToInt32(TextBoxThresholdForAlarm.Text);
                    newThreshold.UpdateThreshold(newThreshold);
                }
            }
        }
    }
}