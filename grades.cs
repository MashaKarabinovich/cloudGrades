public Person gradesInformation(string grades)
        {
            var con = ConfigurationManager.ConnectionStrings["Server=tcp:webmasha1.database.windows.net,1433;Initial Catalog=webmasha;Persist Security Info=False;User ID=Masha123;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"].ToString();

            Person student = new Person();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "Select * from Employees where FirstName=@grades";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@Fname", grades);           
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {    
                        student.id = oReader["ID"].ToString();
                        student.grades = oReader["Grades"].ToString();                       
                    }

                    myConnection.Close();
                }               
            }
            return student;
        }