using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5RahulsirExample.TestApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
                //   txtCountry.
            }
        }

        private void BindGrid()
        {
            try
            {

                CustomerProjecttablsssEntities1 dbContext = new CustomerProjecttablsssEntities1();
                var query1 = from cust in dbContext.Customers
                               select cust;


                            GridView1.DataSource = query1.ToList();
                            GridView1.DataBind();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        //protected void Insert(object sender, EventArgs e)
        //{
        //    string name = txtName.Text;
        //    string country = txtCountry.Text;
        //    txtName.Text = "";
        //    txtCountry.Text = "";
        //    string query = "INSERT INTO Customers VALUES(@Name, @Country)";
        //    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(query))
        //        {
        //            cmd.Parameters.AddWithValue("@Name", name);
        //            cmd.Parameters.AddWithValue("@Country", country);
        //            cmd.Connection = con;
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //    }
        //    this.BindGrid();
        //}               
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int customerId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string name = (row.FindControl("txtName") as TextBox).Text;
            string country = (row.FindControl("txtCountry") as TextBox).Text;
            string query = "UPDATE Customers SET Name=@Name, Country=@Country WHERE CustomerId=@CustomerId";
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Country", country);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            GridView1.EditIndex = -1;
            this.BindGrid();
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int customerId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string query = "DELETE FROM Customers WHERE CustomerId=@CustomerId";
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            this.BindGrid();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    for (int colIndex = 0; colIndex < e.Row.Cells.Count; colIndex++)
                    {
                        int rowIndex = colIndex;
                        TextBox txtName = new TextBox();
                        txtName.Width = 16;
                        txtName.ID = "txtboxname" + colIndex;
                        txtName.AutoPostBack = true;
                        e.Row.Cells[colIndex].Controls.Add(txtName);
                        TextBox txtName1 = new TextBox();
                        txtName1.Width = 16;
                        txtName1.BackColor = System.Drawing.Color.LightBlue;
                        txtName1.ID = "txtboxname1" + colIndex;
                        txtName1.ReadOnly = true;
                        e.Row.Cells[colIndex].Controls.Add(txtName1);
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }

        protected void BtnOnClick(object sender, EventArgs e)
        {
                      
            Customer _customer = new Customer();
            List<Customer> _lstCustomer = new List<Customer>();
            var button = sender as Button;
            var view = button.FindControl("GridView1") as GridView;
            foreach (GridViewRow row in GridView1.Rows)
            {
                // Selects the text from the TextBox
                // which is inside the GridView control
                int rowIndex = row.RowIndex;
                _customer.Id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]);
                _customer.Name = ((Label)row.FindControl("lblName")).Text;
                _customer.Country = ((TextBox)row.FindControl("txtCountry")).Text;

                _lstCustomer.Add(_customer);
                _customer = new Customer();
            }
            foreach(var _customers in _lstCustomer)
            {
                using (CustomerProjecttablsssEntities1 dbContext = new CustomerProjecttablsssEntities1())
                {
                    Customer customer = (from c in dbContext.Customers
                                         where c.Id == _customers.Id
                                         select c).FirstOrDefault();
                    customer.Name = _customers.Name;
                    customer.Country = _customers.Country;
                   // dbContext.Customers.Add(customer);
                    dbContext.SaveChanges();
                }
            }
            BindGrid();
            // DataTable dt = new DataTable("MyTable");
            //dt = ConvertToDataTable(_lstCustomer);

            //using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerProjecttablsssConnectionString"].ConnectionString))
            //{
            //    using (SqlCommand command = new SqlCommand("", conn))
            //    {
            //        try
            //        {
            //            conn.Open();

            //            //Creating temp table on database

            //            command.CommandText = "CREATE TABLE #TmpTable([ID] [int] NOT NULL, [Name][varchar](50) NULL, [Country] [varchar] (50) NULL)";
            //            command.ExecuteNonQuery();

            //            //Bulk insert into temp table
            //            using (SqlBulkCopy bulkcopy = new SqlBulkCopy(conn))
            //            {
            //                bulkcopy.BulkCopyTimeout = 660;
            //                bulkcopy.DestinationTableName = "#TmpTable";
            //                bulkcopy.WriteToServer(dt);
            //                bulkcopy.Close();
            //            }

            //            // Updating destination table, and dropping temp table
            //            command.CommandTimeout = 300;
            //            command.CommandText = "UPDATE T SET T.Country=Temp.Country FROM Customers T INNER JOIN #TmpTable Temp ON T.ID = Temp.ID; DROP TABLE #TmpTable;";
            //            command.ExecuteNonQuery();

            //            BindGrid();
            //        }
            //        catch (Exception ex)
            //        {
            //            // Handle exception properly
            //        }
            //        finally
            //        {
            //            conn.Close();
            //        }
            //    }
            //}

        }
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
       
    }
}