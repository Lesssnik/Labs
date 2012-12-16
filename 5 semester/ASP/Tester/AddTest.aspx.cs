using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL
{
    public partial class AddTest : System.Web.UI.Page
    {
        static Entities.Types type;
        static List<Entities.Question> QuestionList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QuestionList = new List<Entities.Question>();
                TypesId.DataSource = Enum.GetNames(typeof(Entities.Types));
                DataBind();
            }
        }

        protected void Create_Click(object sender, EventArgs e)
        {
            TestComponents tc = new TestComponents();
            Entities.Test test = new Entities.Test();
            test.Name = NameId.Value;
            test.Description = DescrId.Value;
            test.Type = type;
            test.Author = Session["UserLogin"].ToString();
            test.Time = new TimeSpan(int.Parse(HourTimeId.Value), int.Parse(MinuteTimeId.Value), int.Parse(SecondTimeId.Value));
            test.Questions.AddRange(QuestionList);
            tc.AddTest(test);
          
            Response.Redirect("Default.aspx");
        }

        protected void TypesId_SelectedIndexChanged(object sender, EventArgs e)
        {
            type = (Entities.Types)Enum.Parse(typeof(Entities.Types), TypesId.SelectedValue);
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            QuestionList.Add(new Entities.Question());
            QuestionList[QuestionList.Count - 1].Text = QuestionText.Text;
            QuestionText.Text = "";
            if (Answer1.Value != "")
            {
                QuestionList[QuestionList.Count - 1].Answers.Add(new Entities.Answer() { Text = Answer1.Value, IsTrue = CheckResAnswer1.Checked });
                Answer1.Value = "";
                CheckResAnswer1.Checked = false;
            }
            if (Answer2.Value != "")
            {
                QuestionList[QuestionList.Count - 1].Answers.Add(new Entities.Answer() { Text = Answer2.Value, IsTrue = CheckResAnswer2.Checked });
                Answer2.Value = "";
                CheckResAnswer2.Checked = false;
            }
            if (Answer3.Value != "")
            {
                QuestionList[QuestionList.Count - 1].Answers.Add(new Entities.Answer() { Text = Answer3.Value, IsTrue = CheckResAnswer3.Checked });
                Answer3.Value = "";
                CheckResAnswer3.Checked = false;
            }
            if (Answer4.Value != "")
            {
                QuestionList[QuestionList.Count - 1].Answers.Add(new Entities.Answer() { Text = Answer4.Value, IsTrue = CheckResAnswer4.Checked });
                Answer4.Value = "";
                CheckResAnswer4.Checked = false;
            }
            if (Answer5.Value != "")
            {
                QuestionList[QuestionList.Count - 1].Answers.Add(new Entities.Answer() { Text = Answer5.Value, IsTrue = CheckResAnswer5.Checked });
                Answer5.Value = "";
                CheckResAnswer5.Checked = false;
            }
            if (Answer6.Value != "")
            {
                QuestionList[QuestionList.Count - 1].Answers.Add(new Entities.Answer() { Text = Answer6.Value, IsTrue = CheckResAnswer6.Checked });
                Answer6.Value = "";
                CheckResAnswer6.Checked = false;
            }
        }
    }
}