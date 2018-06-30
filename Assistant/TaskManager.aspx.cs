using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TaskManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    private List<TasksDto> PopulateCountry()
    {
        List<TasksDto> dummyTasks = new List<TasksDto>()
        {
            new TasksDto()
            {
                Title = "Estudiar de math",
                Description = "Estudiar temas 1 - 6",
                StartDate = Convert.ToDateTime("2018-06-15"),
                EndDate = Convert.ToDateTime("2018-06-22"),
                Active = true
            },
            new TasksDto()
            {
                Title = "Estudiar de Etica",
                Description = "Sobre la criminalidad en la sociedad",
                StartDate = Convert.ToDateTime("2018-06-10"),
                EndDate = Convert.ToDateTime("2018-06-17"),
                Active = true
            },
            new TasksDto()
            {
                Title = "Reunion con Fulano",
                Description = "Coordinar la sorpresa para Sutano",
                StartDate = Convert.ToDateTime("2018-06-20"),
                EndDate = Convert.ToDateTime("2018-06-20"),
                Active = true
            }
        };
        return dummyTasks;
    }

    private void BindCountry(DropDownList ddCountry, List<TasksDto> task)
    {
        ddCountry.Items.Clear();
        ddCountry.Items.Add(new ListItem { Text = "Select Task", Value = "0" });
        ddCountry.AppendDataBoundItems = true;

        ddCountry.DataTextField = "CountryName";
        ddCountry.DataValueField = "CountryID";
        ddCountry.DataSource = task;
        ddCountry.DataBind();
    }
    private void PopulateContacts()
    {
        List<TasksDto> allContacts = null;
        using (MyDatabaseEntities dc = new MyDatabaseEntities())
        {
            var contacts = (from a in dc.Contacts
                join b in dc.Countries on a.CountryID equals b.CountryID
                join c in dc.States on a.StateID equals c.StateID
                select new
                {
                    a,
                    b.CountryName,
                    c.StateName
                });
            if (contacts != null)
            {
                allContacts = new List<TasksDto>();
                foreach (var i in contacts)
                {
                    Contact c = i.a;
                    c.CountryName = i.CountryName;
                    c.StateName = i.StateName;
                    allContacts.Add(c);
                }
            }

            if (allContacts == null || allContacts.Count == 0)
            {
                //trick to show footer when there is no data in the gridview
                allContacts.Add(new TasksDto());
                myGridview.DataSource = allContacts;
                myGridview.DataBind();
                myGridview.Rows[0].Visible = false;
            }
            else
            {
                myGridview.DataSource = allContacts;
                myGridview.DataBind();
            }

            //Populate & bind country
            if (myGridview.Rows.Count > 0)
            {
                DropDownList dd = (DropDownList)myGridview.FooterRow.FindControl("ddCountry");
                BindCountry(dd, PopulateCountry());
            }

        }
    }
}