using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL
{
    public partial class EditTest : System.Web.UI.Page
    {
        static Entities.Types type;
        static List<Entities.Question> QuestionList = new List<Entities.Question>();
        static List<string> TextQuestionList = new List<string>();
        static string TestId;
        static Entities.Test test;

        protected void Page_Load(object sender, EventArgs e)
        {
            TestId = Request["test"];
            test = new TestComponents().FindTest(Guid.Parse(TestId));
            NameId.Value = test.Name;
            DescrId.Value = test.Description;
            if (!IsPostBack)
            {
                QuestionList.AddRange(test.Questions);
                TypesId.DataSource = Enum.GetNames(typeof(Entities.Types));
                TypesId.SelectedValue = test.Type.ToString();
                TextQuestionList.Clear();
                foreach (var q in QuestionList)
                    TextQuestionList.Add(q.Text);
                Questions.DataSource = TextQuestionList;

                for (int i = 0; i < QuestionList[0].Answers.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            Answer1.Value = QuestionList[0].Answers[i].Text;
                            break;
                        case 1:
                            Answer2.Value = QuestionList[0].Answers[i].Text;
                            break;
                        case 2:
                            Answer3.Value = QuestionList[0].Answers[i].Text;
                            break;
                        case 3:
                            Answer4.Value = QuestionList[0].Answers[i].Text;
                            break;
                        case 4:
                            Answer5.Value = QuestionList[0].Answers[i].Text;
                            break;
                        case 5:
                            Answer6.Value = QuestionList[0].Answers[i].Text;
                            break;
                    }
                }

                DataBind();
            }
        }

        protected void Questions_SelectedIndexChanged(object sender, EventArgs e)
        {
            Answer1.Value = "";
            Answer2.Value = "";
            Answer3.Value = "";
            Answer4.Value = "";
            Answer5.Value = "";
            Answer6.Value = "";
            for (int i = 0; i < QuestionList[Questions.SelectedIndex].Answers.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        Answer1.Value = QuestionList[Questions.SelectedIndex].Answers[i].Text;
                        break;
                    case 1:
                        Answer2.Value = QuestionList[Questions.SelectedIndex].Answers[i].Text;
                        break;
                    case 2:
                        Answer3.Value = QuestionList[Questions.SelectedIndex].Answers[i].Text;
                        break;
                    case 3:
                        Answer4.Value = QuestionList[Questions.SelectedIndex].Answers[i].Text;
                        break;
                    case 4:
                        Answer5.Value = QuestionList[Questions.SelectedIndex].Answers[i].Text;
                        break;
                    case 5:
                        Answer6.Value = QuestionList[Questions.SelectedIndex].Answers[i].Text;
                        break;
                }
            }
            DataBind();
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            TestComponents tc = new TestComponents();
            test.Name = NameId.Value;
            test.Description = DescrId.Value;
            test.Type = type;
            test.Author = Session["UserLogin"].ToString();
            test.Time = new TimeSpan(0, 5, 0);
            test.Questions.Clear();
            test.Questions.AddRange(QuestionList);
            tc.UpdateTest(test);
          
            Response.Redirect("Default.aspx");
        }

        protected void TypesId_SelectedIndexChanged(object sender, EventArgs e)
        {
            type = (Entities.Types)Enum.Parse(typeof(Entities.Types), TypesId.SelectedValue);
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            QuestionList[Questions.SelectedIndex].Answers.Clear();
            if (Answer1.Value != "")
            {
                QuestionList[Questions.SelectedIndex].Answers.Add(new Entities.Answer() { Text = Answer1.Value, IsTrue = CheckResAnswer1.Checked });
                Answer1.Value = "";
                CheckResAnswer1.Checked = false;
            }
            if (Answer2.Value != "")
            {
                QuestionList[Questions.SelectedIndex].Answers.Add(new Entities.Answer() { Text = Answer2.Value, IsTrue = CheckResAnswer2.Checked });
                Answer2.Value = "";
                CheckResAnswer2.Checked = false;
            }
            if (Answer3.Value != "")
            {
                QuestionList[Questions.SelectedIndex].Answers.Add(new Entities.Answer() { Text = Answer3.Value, IsTrue = CheckResAnswer3.Checked });
                Answer3.Value = "";
                CheckResAnswer3.Checked = false;
            }
            if (Answer4.Value != "")
            {
                QuestionList[Questions.SelectedIndex].Answers.Add(new Entities.Answer() { Text = Answer4.Value, IsTrue = CheckResAnswer4.Checked });
                Answer4.Value = "";
                CheckResAnswer4.Checked = false;
            }
            if (Answer5.Value != "")
            {
                QuestionList[Questions.SelectedIndex].Answers.Add(new Entities.Answer() { Text = Answer5.Value, IsTrue = CheckResAnswer5.Checked });
                Answer5.Value = "";
                CheckResAnswer5.Checked = false;
            }
            if (Answer6.Value != "")
            {
                QuestionList[Questions.SelectedIndex].Answers.Add(new Entities.Answer() { Text = Answer6.Value, IsTrue = CheckResAnswer6.Checked });
                Answer6.Value = "";
                CheckResAnswer6.Checked = false;
            }

            Questions_SelectedIndexChanged(this, null);
        }
    }
}