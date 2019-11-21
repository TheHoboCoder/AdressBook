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

        static public List<Building> buildingsInfo;

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

        static public long addDep(string name, long buildId, Point location)
        {
            try
            {
                msCommand.CommandText = String.Format("insert into department (name,X,Y,id_build) values ('{0}','{1}','{2}','{3}')", name, location.X, location.Y,buildId);
                msCommand.ExecuteNonQuery();
                return msCommand.LastInsertedId;
            }
            catch (Exception ex)
            {
                return -1;
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

        static public long AddMarker(string name,long buildId,Point location)
        {
            return -1;
        }

        static public void DeleteMarker(int id)
        {

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


        static public bool AddBuilding(Building b)
        {
            try
            {
                msCommand.Parameters["building_data"].Value = Encoding.UTF8.GetString(b.Serialize());
                msCommand.CommandText = "Insert into buildings (name,building_data) values ('{0}',@building_data)";
                msCommand.ExecuteNonQuery();
                if (msCommand.LastInsertedId != -1)
                {
                    b.Id = msCommand.LastInsertedId;
                    buildingsInfo.Add(b);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(), "Ошибка");
                return false;
            }

        }


        static public void loadBuildingData()
        {
            buildingsInfo = new List<Building>();
            msCommand.CommandText = "SELECT * FROM buildings";
            DataTable data = new DataTable();
            msAdapter.Fill(data);
            foreach (DataRow row in data.Rows)
            {
                long id = Convert.ToInt64(row["id_building"]);
                string name = row["name"].ToString();
                byte[] figure_data  = Encoding.UTF8.GetBytes(row["building_data"].ToString());
                Building b = new Building(id, name, figure_data);
                DataTable data2 = new DataTable();
                msCommand.CommandText = String.Format("SELECT * FROM department where id_build = '{0}'",id);
                msAdapter.Fill(data2);
                foreach (DataRow m_row in data2.Rows)
                {
                    Marker m = new Marker(Convert.ToInt64(m_row["id_department"]),
                                           m_row["name"].ToString(),
                                           new Point(Convert.ToInt32(m_row["X"]),Convert.ToInt32(m_row["Y"])));
                    m.BuildingId = id;
                    b.Markers.Add(m);
                }
               
                buildingsInfo.Add(b);

            }
        }

        static public void searchByFam(string fam)
        {
            filterUser.RowFilter = String.Format("fam like '{0}*'", fam);
        }

        //static public void filterBy(int rankId, int )
        //{

        //}


    }
}
