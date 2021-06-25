using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Basic_Form
{
    public partial class BasicForm : System.Web.UI.Page
    {
        private string tempAddressIdHolder;
        private string searchedDob;
        private string searchedGender;

        protected void Page_Load(object sender, EventArgs e)
        {
            TextBoxDOBLabel.Visible = false;
            TextBoxDOB.Visible = false;

            TextBoxGenderLabel.Visible = false;
            TextBoxGender.Visible = false;
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP;Initial Catalog=BasicFormDB;Integrated Security=True");

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[address] WHERE address= '" + txtAddress.Text + "'", conn);
            conn.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 0)
            {
                cmd = new SqlCommand(@"INSERT INTO [dbo].[address] ([address]) VALUES ('" + txtAddress.Text + "')", conn);
                cmd.ExecuteNonQuery();
            }

            cmd = new SqlCommand(@"SELECT addressId FROM [dbo].[address] WHERE [address]='" + txtAddress.Text + "'", conn);
            SqlDataReader drr;
            drr = cmd.ExecuteReader();
            while (drr.Read())
            {
                tempAddressIdHolder = drr["addressId"].ToString();
            }
            drr.Close();

            cmd = new SqlCommand(@"INSERT INTO [dbo].[person]
           ([firstName]
           ,[lastName]
           ,[phoneNumber]
           ,[email]
           ,[dob]
           ,[gender]
           ,[addressId])
     VALUES
           ('" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtPhoneNumber.Text + "','" + txtEmail.Text + "','" + txtDOB.Text + "','" + txtGender.Text + "','" + tempAddressIdHolder + "')", conn);
            cmd.ExecuteNonQuery();

            Response.Write("Data added successfully!");
            conn.Close();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-6C5QL4B\\SQLEXPRESS;Initial Catalog=BasicFormDB;Integrated Security=True");

            SqlCommand cmd = new SqlCommand(@"SELECT addressId FROM [dbo].[person] WHERE [firstName]='" + txtFirstName.Text + "' AND [lastName]='" + txtLastName.Text + "'", conn);
            SqlDataReader drr;
            conn.Open();
            drr = cmd.ExecuteReader();
            while (drr.Read())
            {
                tempAddressIdHolder = drr["addressId"].ToString();
            }
            drr.Close();

            cmd = new SqlCommand(@"DELETE FROM [dbo].[person]
      WHERE [firstName]='" + txtFirstName.Text + "' AND [lastName]='" + txtLastName.Text + "'", conn);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[person] WHERE addressId= '" + tempAddressIdHolder + "'", conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 0)
            {
                cmd = new SqlCommand(@"DELETE FROM [dbo].[address]
      WHERE [addressId]='" + tempAddressIdHolder + "'", conn);
                cmd.ExecuteNonQuery();
            }

            Response.Write("Data deleted successfully!");
            conn.Close();
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-6C5QL4B\\SQLEXPRESS;Initial Catalog=BasicFormDB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(@"SELECT addressId FROM [dbo].[address] WHERE [address]='" + txtAddress.Text + "'", conn);
            SqlDataReader drr;
            conn.Open();
            drr = cmd.ExecuteReader();
            while (drr.Read())
            {
                tempAddressIdHolder = drr["addressId"].ToString();
            }
            drr.Close();

            

            cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[address] WHERE address= '" + txtAddress.Text + "'", conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 0) // there are no addresses found in address table based on input, so add address
            {
                cmd = new SqlCommand(@"INSERT INTO [dbo].[address]
            ([address])
     VALUES
           ('" + txtAddress.Text + "')", conn);
                cmd.ExecuteNonQuery();

                conn.Close();
                conn.Open();

                cmd = new SqlCommand(@"SELECT addressId FROM [dbo].[address] WHERE [address]='" + txtAddress.Text + "'", conn);
                drr = cmd.ExecuteReader();
                while (drr.Read())
                {
                    tempAddressIdHolder = drr["addressId"].ToString();
                }
                drr.Close();

                cmd = new SqlCommand(@"UPDATE [dbo].[person] SET [addressId]='" + tempAddressIdHolder + "' WHERE [firstName]='" + txtFirstName.Text + "' AND [lastName]='" + txtLastName.Text + "'", conn);
                cmd.ExecuteNonQuery();
            } else // there are address found in the address table, so get the addressid and update person based on id
            {
                cmd = new SqlCommand(@"UPDATE [dbo].[person] SET [addressId]='" + tempAddressIdHolder + "' WHERE [firstName]='" + txtFirstName.Text + "' AND [lastName]='" + txtLastName.Text + "'", conn);
                cmd.ExecuteNonQuery();
            }

            cmd = new SqlCommand(@"UPDATE [dbo].[person] SET [firstName]='" + txtFirstName.Text + "', [lastName]='" + txtLastName.Text + "', [phoneNumber]='" + txtPhoneNumber.Text + "', [email]='" + txtEmail.Text + "', [dob]='" + txtDOB.Text + "', [gender]='" + txtGender.Text + "' WHERE [firstName]='" + txtFirstName.Text + "' AND [lastName]='" + txtLastName.Text + "'", conn);
            cmd.ExecuteNonQuery();
            Response.Write("Data edited successfully!");
            conn.Close();
            
        }

        protected void btnsearch_Click1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-6C5QL4B\\SQLEXPRESS;Initial Catalog=BasicFormDB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM [dbo].[person] WHERE [firstName]='" + txtFirstName.Text + "' AND [lastName]='" + txtLastName.Text + "'", conn);
            conn.Open();
            SqlDataReader drr;
            drr = cmd.ExecuteReader();

            while (drr.Read())
            {
                txtPhoneNumber.Text = drr["phoneNumber"].ToString();
                txtEmail.Text = drr["email"].ToString();
                tempAddressIdHolder = drr["addressId"].ToString();
                searchedDob = drr["dob"].ToString();
                searchedGender = drr["gender"].ToString();
            }
            
            TextBoxDOB.Text = searchedDob.ToString();
            TextBoxDOBLabel.Visible = true;
            TextBoxDOB.Visible = true;

            if(searchedGender!=null)
            {
                TextBoxGender.Text = (string)searchedGender;
                TextBoxGenderLabel.Visible = true;
                TextBoxGender.Visible = true;
            } 
            
            
            drr.Close();

            cmd = new SqlCommand(@"SELECT address FROM [dbo].[address] WHERE [addressId]='" + tempAddressIdHolder + "'", conn);
            drr = cmd.ExecuteReader();
            while (drr.Read())
            {
                txtAddress.Text = drr["address"].ToString();
            }
            drr.Close();

            Response.Write("Data searched successfully!");
            drr.Close();
            conn.Close();
        }
    }

}