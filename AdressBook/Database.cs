using AdressBook.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook
{
    class Database
    {
        static string connectionString = @"Database=adress_book; Data Source = localhost;
                                            UserID=root; Password = 1234";
        static MySqlConnection msConnect;
        static MySqlCommand msCommand;
        static public MySqlDataAdapter msAdapter;

        static public DataTable DepTable = new DataTable();
        static public DataTable RankTable = new DataTable();
        static public DataTable UserTable = new DataTable();
        static public List<BuildingEntity> BuildingData;

        static public DataView filterUser = new DataView(UserTable);

        static public bool Connect()
        {
            try
            {
                msConnect = new MySqlConnection(connectionString);
                msConnect.Open();

                msCommand = new MySqlCommand();
                msCommand.Connection = msConnect;
                msCommand.Parameters.Add("building_data", MySqlDbType.JSON);
                msAdapter = new MySqlDataAdapter(msCommand);
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "Ошибка");
                return false;
            }
        }

        static public void Close()
        {
            msConnect.Close();
        }


        static public void getDeps()
        {
            try
            {
                msCommand.CommandText = "SELECT * FROM department";
                DepTable.Clear();
                msAdapter.Fill(DepTable);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "Ошибка");
            }
        }

        static public bool addDep(string name,Point location)
        {
            try
            {
                msCommand.CommandText = String.Format("insert into department (name,X,Y) values ('{0}','{1}','{2}')", name, location.X, location.Y);
                msCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        static public void addRank(string name)
        {
            msCommand.CommandText = String.Format("insert into rank_t (rank_name) values ('{0}')", name);
            msCommand.ExecuteNonQuery();
        }


        static public void getRanks()
        {
            try
            {
                msCommand.CommandText = "SELECT * FROM rank_t";
                RankTable.Clear();
                msAdapter.Fill(RankTable);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "Ошибка");
            }
        }

        static public long addUser(int depId, int rankId, string fam, string name, string otch, string email, string phone)
        {
            try
            {
                string sql = String.Format("insert into users (id_dep, id_rank,fam,name,otch,phone,email) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                depId, rankId, fam, name, otch, phone, email);
                msCommand.CommandText = sql;
                msCommand.ExecuteNonQuery();
                return msCommand.LastInsertedId;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "Ошибка");
                return -1;
            }
        }

        static public void getDepData()
        {

        }

        static public void getUsers()
        {
            try
            {
                msCommand.CommandText = "SELECT fam,name,otch,lat,lng,id_dep,id_rank FROM users";
                UserTable.Clear();
                msAdapter.Fill(UserTable);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "Ошибка");
            }
        }


        //static public void getBuildingData()
        //{
        //    BuildingData = new List<BuildingEntity>();
        //    msCommand.CommandText = "SELECT * FROM buildings";
        //    DataTable data = new DataTable();
        //    msAdapter.Fill(data);
        //    foreach(DataRow row in data.Rows)
        //    {
        //        byte[] figure_data = null;
        //        figure_data = Encoding.UTF8.GetBytes(row["building_data"].ToString());
        //        BuildingEntity e = new BuildingEntity();
        //        e.building = Building.Deserialize(figure_data);
        //        e.id = Convert.ToInt32(row["id_building"]);
        //        BuildingData.Add(e);
        //    }
        //}

        //static public void Add




        static public void searchByFam(string fam)
        {
            filterUser.RowFilter = String.Format("fam like '{0}*'", fam);
        }

        //static public void filterBy(int rankId, int )
        //{

        //}


    }
}
