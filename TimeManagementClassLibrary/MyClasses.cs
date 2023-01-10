using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows;
using System.Xml.Linq;

namespace TimeManagementClassLibrary
{
    public class StudyHours
    {
        //checks if using db
        public bool busy = false;
        public bool inserted = false;

        //Primary key = identity field
        public int StudyHoursID { get; set; }
        public int Week { get; set; }
        public double RemainingStudyHours { get; set; }
        public DateTime Date { get; set; }
        public int ModuleID { get; set; }

        public StudyHours(int week, double remainingStudyHours, DateTime date, int moduleID)
        {
            Week = week;
            RemainingStudyHours = remainingStudyHours;
            Date = date;
            ModuleID = moduleID;
            InsertDB();
        }

        //StudyHours from db
        public StudyHours(int id, int week, double remainingStudyHours, DateTime date, int moduleID)
        {
            StudyHoursID = id;
            Week = week;
            RemainingStudyHours = remainingStudyHours;
            Date = date;
            ModuleID = moduleID;
        }

        private void InsertDB()
        {
            busy = true;
            //SqlDateTime adapted from
            //https://stackoverflow.com/questions/17418258/datetime-format-to-sql-format-using-c-sharp
            //User answered
            //https://stackoverflow.com/users/1538014/mkb
            //Accessed 13 November 2022
            string query = $"INSERT INTO StudyHours (Week, RemainingStudyHours, Date, ModuleID) VALUES ({Week}, {RemainingStudyHours}, '{new SqlDateTime(Date).ToSqlString()}', {ModuleID});";
            //Use connection string stored in project settings
            using (SqlConnection connection = new(Properties.Settings.Default.DBCS))
            {
                SqlCommand command = new(query, connection);
                try
                {
                    connection.Open();
                    int num = command.ExecuteNonQuery();
                    //MessageBox.Show("Successfully added studyhours for week " + Week);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("StudyHours: " + ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Week = 0;
                }
                //Get surrogate key
                query = $"SELECT StudyHoursID FROM StudyHours WHERE Week = '{Week}' AND ModuleID = '{ModuleID}';";
                command = new(query, connection);
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    StudyHoursID = (int)reader["StudyHoursID"];
                    //MessageBox.Show("ID of studyhours is " + StudyHoursID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("StudyHours: " + ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Week = 0;
                }
                command.Dispose();
                
            }
            busy = false;
            inserted = true;
        }
    }

    public class Module
    {
        //checks if using db
        public bool busy = false;
        public bool inserted = false;

        //Primary key = identity field
        public int ModuleID { get; set; }
        public string Code { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public int NumCredits { get; private set; }
        public int ClassHoursPerWeek { get; private set; }
        public double SelfStudyHoursPerWeek { get; private set; }
        public Semester ModuleSemester { get; private set; }
        public string SemesterID { get; set; } = string.Empty;
        //StudyHours List for Weeks with remaining study hours
        public List<StudyHours> st = new();

        //For modules without a semester yet
        public static readonly Semester tempSemester = new("TEMP", 0, new DateTime(2000, 1, 1), "_", false);

        public Module(string code, string name, int numCredits, int classHoursPerWeek, Semester s)
        {
            Code = code;
            Name = name;
            NumCredits = numCredits;
            ClassHoursPerWeek = classHoursPerWeek;
            ModuleSemester = s;
            //Calculate required self study hours
            SelfStudyHoursPerWeek = ((NumCredits * 10) / ModuleSemester.NumWeeks) - ClassHoursPerWeek;
            SemesterID = s.SemesterID;
            InsertDB();
            //Assign starting weekly remaining study hours
            for (int i = 0; i < ModuleSemester.NumWeeks; i++)
            {
                TimeSpan ts = new(i * 7, 0, 0, 0);
                st.Add(new StudyHours(i + 1, SelfStudyHoursPerWeek, ModuleSemester.StartDate + ts, this.ModuleID));
            }
        }

        //Modules from db
        public Module(int id, string code, string name, int numCredits, int classHoursPerWeek, Semester s, bool insert)
        {
            ModuleID = id;
            Code = code;
            Name = name;
            NumCredits = numCredits;
            ClassHoursPerWeek = classHoursPerWeek;
            ModuleSemester = s;
            //Calculate required self study hours
            SelfStudyHoursPerWeek = ((NumCredits * 10) / ModuleSemester.NumWeeks) - ClassHoursPerWeek;
            SemesterID = s.SemesterID;
            inserted = insert;
        }

        //For modules without a semester yet
        public Module(string code, string name, int numCredits, int classHoursPerWeek)
        {
            Code = code;
            Name = name;
            NumCredits = numCredits;
            ClassHoursPerWeek = classHoursPerWeek;
            ModuleSemester = tempSemester;
        }

        private void InsertDB()
        {
            busy = true;
            string query = $"INSERT INTO Module (Code, Name, NumCredits, ClassHoursPerWeek, SelfStudyHoursPerWeek, SemesterID) VALUES ('{Code}', '{Name}', {NumCredits}, {ClassHoursPerWeek}, {SelfStudyHoursPerWeek}, '{SemesterID}');";
            //Use connection string stored in project settings
            using (SqlConnection connection = new(Properties.Settings.Default.DBCS))
            {
                SqlCommand command = new(query, connection);
                try
                {
                    connection.Open();
                    int num = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("truncated") && ex.Message.Contains("Code"))
                    {
                        MessageBox.Show("Module Code cannot be longer than 10 characters", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (ex.Message.Contains("truncated") && ex.Message.Contains("Name"))
                    {
                        MessageBox.Show("Module Name cannot be longer than 50 characters", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show("Module: " + ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    Name = "Fail";
                }
                //Get surrogate key
                query = $"SELECT ModuleID FROM Module WHERE Code = '{Code}' AND SemesterID = '{SemesterID}';";
                command = new(query, connection);
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    ModuleID = (int)reader["ModuleID"];
                    //MessageBox.Show("ID of module is " + ModuleID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Module: " + ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Name = "Fail";
                }
                command.Dispose();
            }
            busy = false;
            inserted = true;
        }

        public void SetSemester(Semester s)
        {
            ModuleSemester = s;
            //Calculate required self study hours
            SelfStudyHoursPerWeek = ((NumCredits * 10) / ModuleSemester.NumWeeks) - ClassHoursPerWeek;
            SemesterID = s.SemesterID;
            InsertDB();
            //Assign starting weekly remaining study hours
            for (int i = 0; i < ModuleSemester.NumWeeks; i++)
            {
                TimeSpan ts = new(i * 7, 0, 0, 0);
                st.Add(new StudyHours(i + 1, SelfStudyHoursPerWeek, ModuleSemester.StartDate + ts, this.ModuleID));
            }
        }

        public override string ToString()
        {
            string message = "Code:\t" + Code
                + "\nName:\t" + Name
                + "\nCredits:\t" + NumCredits
                + "\nRemaining Study Hours\n---\n";
            for (int i = 0; i < st.Count; i++)
            {
                message += "Week " + st[i].Week + " (" + st[i].Date.ToString("dd/MM/yyyy") + "): " + st[i].RemainingStudyHours + "\n";
            }
            return message + "____________________________________________________\n\n";
        }
    }

    public class Semester
    {
        //checks if using db
        public bool busy = false;
        public bool inserted = false;

        public List<Module> modules = new();
        //Must be StudentNum + SemesterName
        public string SemesterID { get; set; } = string.Empty;
        public string SemesterName { get; set; } = string.Empty;
        public int NumWeeks { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; private set; }
        public string StudentNum { get; set; } = string.Empty;

        public Semester(string semesterName, int numWeeks, DateTime startDate, string studentNum)
        {
            SemesterName = semesterName;
            NumWeeks = numWeeks;
            StartDate = startDate;
            TimeSpan ts = new(numWeeks * 7, 0, 0, 0);
            EndDate = startDate + ts;
            StudentNum = studentNum;
            SemesterID = StudentNum + "_" + SemesterName;
            InsertDB();
        }

        public Semester(string semesterName, int numWeeks, DateTime startDate, string studentNum, bool insert)
        {
            SemesterName = semesterName;
            NumWeeks = numWeeks;
            StartDate = startDate;
            TimeSpan ts = new(numWeeks * 7, 0, 0, 0);
            EndDate = startDate + ts;
            StudentNum = studentNum;
            SemesterID = StudentNum + "_" + SemesterName;
            inserted = insert;
        }

        private void InsertDB()
        {
            busy = true;
            //SqlDateTime adapted from
            //https://stackoverflow.com/questions/17418258/datetime-format-to-sql-format-using-c-sharp
            //User answered
            //https://stackoverflow.com/users/1538014/mkb
            //Accessed 13 November 2022
            string query = $"INSERT INTO Semester (SemesterID, SemesterName, NumWeeks, StartDate, EndDate, StudentNum) VALUES ('{SemesterID}', '{SemesterName}', {NumWeeks}, '{new SqlDateTime(StartDate).ToSqlString()}', '{new SqlDateTime(EndDate).ToSqlString()}', '{StudentNum}');";
            //Use connection string stored in project settings
            using (SqlConnection connection = new(Properties.Settings.Default.DBCS))
            {
                SqlCommand command = new(query, connection);
                try
                {
                    connection.Open();
                    int num = command.ExecuteNonQuery();
                    //MessageBox.Show("Successfully added semester");
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("truncated") && ex.Message.Contains("SemesterName"))
                    {
                        MessageBox.Show("Semester Name cannot be longer than 50 characters", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (ex.Message.Contains("duplicate") && ex.Message.Contains("SemesterID"))
                    {
                        MessageBox.Show("Semester already exists", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show("Semester: " + ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    SemesterName = "Fail";
                }
                command.Dispose();
            }
            busy = false;
            inserted = true;
        }

        public bool AddModule(Module module)
        {
            foreach (var m in modules)
            {
                if (m.Code.Equals(module.Code))
                {
                    //Duplicate module code detected
                    return false;
                }
            }
            modules.Add(module);
            return true;
        }

        public bool AddModule(IList<Module> module)
        {
            //Add List of Modules
            bool result = true;
            foreach (var m in module)
            {
                if (!AddModule(m))
                {
                    result = false;
                }
            }
            return result;
        }

        public void RemoveModule(string moduleCode)
        {
            foreach (var module in modules)
            {
                if (module.Code.Equals(moduleCode))
                {
                    modules.Remove(module);
                }
            }
        }
    }

    public class Student
    {
        //checks if using db
        public bool busy = false;
        public bool inserted = false;

        public string StudentNum { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public Student(string studentNum, string name, string password)
        {
            StudentNum = studentNum;
            Name = name;
            //Hash password
            Password = Hash(password);
            InsertDB();
            //Prevents UI lockup (Doesn't work well for login and registration)
            //Thread DBThread = new(InsertDB);
            //DBThread.Start();
        }

        //Doesn't attempt to insert student into the database
        public Student(string studentNum, string name, string password, bool insert)
        {
            StudentNum = studentNum;
            Name = name;
            //Hash password
            Password = Hash(password);
            inserted = insert;
        }

        private void InsertDB()
        {
            busy = true;
            string query = $"INSERT INTO Student (StudentNum, [Name], [Password]) VALUES ('{StudentNum}', '{Name}', '{Password}');";
            //Use connection string stored in project settings
            using (SqlConnection connection = new(Properties.Settings.Default.DBCS))
            {
                SqlCommand command = new(query, connection);
                try
                {
                    connection.Open();
                    int num = command.ExecuteNonQuery();
                    //MessageBox.Show("Successfully Registered");
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("truncated") && ex.Message.Contains("StudentNum"))
                    {
                        MessageBox.Show("Student number cannot be longer than 10 characters", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (ex.Message.Contains("truncated") && ex.Message.Contains("Name"))
                    {
                        MessageBox.Show("Name cannot be longer than 50 characters", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else if (ex.Message.Contains("duplicate"))
                    {
                        MessageBox.Show("Student number already exists", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show("Student: " + ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    StudentNum = "Fail";
                }
            }
            busy = false;
            inserted = true;
        }

        public static string Hash(string value)
        {
            //Hash value obtained from
            //https://stackoverflow.com/questions/16999361/obtain-sha-256-string-of-a-string/17001289#17001289
            //User answered:
            //https://stackoverflow.com/users/14608904/samuel-johnson
            //Accessed 12 November 2022
            using var hash = SHA256.Create();
            var byteArray = hash.ComputeHash(Encoding.UTF8.GetBytes(value));
            return Convert.ToHexString(byteArray);
        }

    }
}
