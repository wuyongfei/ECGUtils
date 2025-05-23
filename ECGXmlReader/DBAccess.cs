using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ECGXmlReader;

/// <summary>
/// SQLITE数据库访问方法。全部是静态方法。
/// </summary>
public static class DBAccess
{
    /// <summary>
    /// 2, 5 not used for now
    /// </summary>
    public enum LabelState : int
    {
        INIT = 0,
        REDO = 1,
        COMPLETE = 2,
        AUDITING = 5,
        FINISHED = 9
    }

    /// <summary>
    /// 创建数据库。务必保证只在第一次使用时调用
    /// </summary>
    /// <param name="dbPath"></param>
    /// <returns></returns>
    public static bool CreateDatabase(string dbPath)
    {
        bool b = false;

        try
        {
            string createsql = @"
                CREATE TABLE Labels (
                    Id         INTEGER CONSTRAINT PK_Labels PRIMARY KEY AUTOINCREMENT,
                    Fullpath   TEXT    UNIQUE
                                       NOT NULL,
                    HeaderInfo TEXT    NOT NULL,
                    LeadsInfo  TEXT    NOT NULL,
                    LabelList  TEXT    NOT NULL,
                    CreateUser TEXT,
                    CreateDate TEXT,
                    UpdateUser TEXT,
                    UpdateDate TEXT,
                    Status     INTEGER DEFAULT (0),
                    Blob       BLOB
                )
            ";

 
            using (var connection = new SqliteConnection($"Data Source={dbPath};"))
            {
                connection.Open();

                // Create a table with a BLOB column
                using (var command = new SqliteCommand(createsql, connection))
                {
                    int i = command.ExecuteNonQuery();
                    b = (i > -1);
                }
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine($"[DBAccess.CreateDatabase] {e.Message} {e.StackTrace}");

            throw;
        }

        return b;
    }

    /// <summary>
    /// 添加一条记录。返回Id
    /// 
    /// 新纪录中的CreateUser=UpdateUser, CreateDate=UpdateDate
    /// </summary>
    /// <param name="dbPath"></param>
    /// <param name="label"></param>
    /// <returns></returns>
    public static long Insert(string dbPath, Label label)
    {
        long newID = -1;
        try
        {
            using (var connection = new SqliteConnection($"Data Source={dbPath};"))
            {
                connection.Open();
                string sqlInsert = @"INSERT INTO Labels (
                                       Fullpath,
                                       HeaderInfo,
                                       LeadsInfo,
                                       LabelList,
                                       CreateUser,
                                       CreateDate,
                                       UpdateUser,
                                       UpdateDate,
                                       Status,
                                       Blob
                                   ) VALUES (
                                       @Fullpath,
                                       @HeaderInfo,
                                       @LeadsInfo,
                                       @LabelList,
                                       @CreateUser,
                                       @CreateDate,
                                       @UpdateUser,
                                       @UpdateDate,
                                       @Status,
                                       @Blob
                                   )";

                using (var command = new SqliteCommand(sqlInsert, connection))
                {
                    command.Parameters.AddWithValue("@Fullpath", label.Fullpath);
                    command.Parameters.AddWithValue("@HeaderInfo", label.HeaderInfo);
                    command.Parameters.AddWithValue("@LeadsInfo", label.LeadsInfo);
                    command.Parameters.AddWithValue("@LabelList", label.LabelList);
                    command.Parameters.AddWithValue("@CreateUser", label.CreateUser);
                    command.Parameters.AddWithValue("@CreateDate", label.CreateDate);
                    command.Parameters.AddWithValue("@UpdateUser", label.UpdateUser);
                    command.Parameters.AddWithValue("@UpdateDate", label.UpdateDate);
                    command.Parameters.AddWithValue("@Status", label.Status);
                    command.Parameters.AddWithValue("@Blob", label.Blob);

                    int i = command.ExecuteNonQuery();

                    if (i > 0)
                    {
                        string sql = @"select last_insert_rowid()";
                        command.CommandText = sql;
                        newID = (long)command.ExecuteScalar();
                    }
                }

            }
        }
        catch (Exception e)
        {
            Debug.WriteLine($"[DBAccess.Insert] {e.Message} {e.StackTrace}");
        }

        return newID;
    }

    /// <summary>
    /// 删除一条记录
    /// </summary>
    /// <param name="dbPath"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public static bool Delete(string dbPath, int id)
    {
        bool b = false;
        try
        {
            using (var connection = new SqliteConnection($"Data Source={dbPath};"))
            {
                connection.Open();

                string sqlDelete = @"DELETE 
                                     FROM Labels
                                     WHERE Id = @Id";
                
                using (var command = new SqliteCommand(sqlDelete, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    int i = command.ExecuteNonQuery();

                    b = (i > 0);
                }

            }
        }
        catch (Exception e)
        {
            Debug.WriteLine($"[DBAccess.Delete] {e.Message} {e.StackTrace}");
        }

        return b;
    }

    /// <summary>
    /// 只能够更新标注数据
    /// </summary>
    /// <param name="dbPath"></param>
    /// <param name="label"></param>
    /// <returns></returns>
    public static bool Update(string dbPath, Label label)
    {
        bool b = false;
        try
        {
            using (var connection = new SqliteConnection($"Data Source={dbPath};"))
            {
                connection.Open();

                // do not update  Blob = @Blob
                string sqlUpdate = @"UPDATE Labels
                                       SET UpdateUser = @UpdateUser,
                                           UpdateDate = @UpdateDate,
                                           LabelList = @LabelList,
                                           Status = @Status
                                     WHERE Id = @Id";

                using (var command = new SqliteCommand(sqlUpdate, connection))
                {
                    //command.Parameters.AddWithValue("@Fullpath", label.Fullpath);
                    //command.Parameters.AddWithValue("@HeaderInfo", label.HeaderInfo);
                    //command.Parameters.AddWithValue("@LeadsInfo", label.LeadsInfo);
                    //command.Parameters.AddWithValue("@CreateUser", label.CreateUser);
                    //command.Parameters.AddWithValue("@CreateDate", label.CreateDate);
                    command.Parameters.AddWithValue("@UpdateUser", label.UpdateUser);
                    command.Parameters.AddWithValue("@UpdateDate", label.UpdateDate);
                    command.Parameters.AddWithValue("@LabelList", label.LabelList);
                    command.Parameters.AddWithValue("@Status", label.Status);

                    // command.Parameters.AddWithValue("@Blob", label.Blob);

                    command.Parameters.AddWithValue("@Id", label.Id);

                    int i = command.ExecuteNonQuery();

                    b = (i > 0);
                }

            }
        }
        catch (Exception e)
        {
            Debug.WriteLine($"[DBAccess.Update] {e.Message} {e.StackTrace}");
        }

        return b;
    }

    public static bool Update(string dbPath, int id, string updateUser, string labellist, int status)
    {
        bool b = false;
        try
        {
            using (var connection = new SqliteConnection($"Data Source={dbPath};"))
            {
                connection.Open();

                // do not update  Blob = @Blob
                string sqlUpdate = @"UPDATE Labels
                                       SET UpdateUser = @UpdateUser,
                                           UpdateDate = @UpdateDate,
                                           LabelList = @LabelList,
                                           Status = @Status
                                     WHERE Id = @Id";

                using (var command = new SqliteCommand(sqlUpdate, connection))
                {
                    command.Parameters.AddWithValue("@UpdateUser", updateUser);
                    command.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                    command.Parameters.AddWithValue("@LabelList", labellist);
                    command.Parameters.AddWithValue("@Status", status);

                    command.Parameters.AddWithValue("@Id", id);

                    int i = command.ExecuteNonQuery();

                    b = (i > 0);
                }

            }
        }
        catch (Exception e)
        {
            Debug.WriteLine($"[DBAccess.Update2] {e.Message} {e.StackTrace}");
        }

        return b;
    }

    public static bool UpdateStatus(string dbPath, int id, string updateUser, int status)
    {
        bool b = false;
        try
        {
            using (var connection = new SqliteConnection($"Data Source={dbPath};"))
            {
                connection.Open();

                // do not update  Blob = @Blob
                string sqlUpdate = @"UPDATE Labels
                                       SET UpdateUser = @UpdateUser,
                                           UpdateDate = @UpdateDate,
                                           Status = @Status
                                     WHERE Id = @Id";

                using (var command = new SqliteCommand(sqlUpdate, connection))
                {
                    command.Parameters.AddWithValue("@UpdateUser", updateUser);
                    command.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                    command.Parameters.AddWithValue("@Status", status);

                    command.Parameters.AddWithValue("@Id", id);

                    int i = command.ExecuteNonQuery();

                    b = (i > 0);
                }

            }
        }
        catch (Exception e)
        {
            Debug.WriteLine($"[DBAccess.UpdateStatus] {e.Message} {e.StackTrace}");
        }

        return b;
    }

    /// <summary>
    /// 通过Id获取一条记录
    /// </summary>
    /// <param name="dbPath"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public static LabelDTO GetById(string dbPath, int id)
    {
        try
        {
            Label label = new Label();

            using (var connection = new SqliteConnection($"Data Source={dbPath};"))
            {
                connection.Open();
                string sqlSelect = @"SELECT Id,
                                       Fullpath,
                                       HeaderInfo,
                                       LeadsInfo,
                                       LabelList,
                                       CreateUser,
                                       CreateDate,
                                       UpdateUser,
                                       UpdateDate,
                                       Status,
                                       Blob
                                    FROM Labels
                                    WHERE Id = @Id";

                using (var command = new SqliteCommand(sqlSelect, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieve data from the row
                            label.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            label.Fullpath = reader.GetString(reader.GetOrdinal("Fullpath"));
                            
                            label.HeaderInfo = reader.GetString(reader.GetOrdinal("HeaderInfo"));
                            label.LeadsInfo = reader.GetString(reader.GetOrdinal("LeadsInfo"));
                            label.LabelList = reader.GetString(reader.GetOrdinal("LabelList"));
                            
                            label.CreateUser = reader.GetString(reader.GetOrdinal("CreateUser"));
                            label.UpdateUser = reader.GetString(reader.GetOrdinal("UpdateUser"));
                            label.CreateDate = reader.GetDateTime(reader.GetOrdinal("CreateDate"));
                            label.UpdateDate = reader.GetDateTime(reader.GetOrdinal("UpdateDate"));

                            label.Status = reader.GetInt32(reader.GetOrdinal("Status"));

                            // byte[] data = (byte[])reader["Blob"]; // Assuming "data" is a BLOB column
                            label.Blob = (byte[])reader["Blob"];

                            // Convert the byte array back to an int16 array (if needed)
                            LabelDTO dto = new LabelDTO(label);

                            //label.Digits = new short[data.Length / sizeof(short)];
                            //Buffer.BlockCopy(data, 0, label.Digits, 0, data.Length);

                            // Print the retrieved data
                            // Console.WriteLine($"Retrieved row with Id: {id}");
                            // Console.WriteLine("Data as int16 array: " + string.Join(", ", label.Digits));
                            return dto;
                        }
                        else
                        {
                            Console.WriteLine($"No row found with Id: {id}");
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine($"[DBAccess.GetById] {e.Message} {e.StackTrace}");
        }

        return null;
    }

    public static List<LabelShortForm> GetLabels(string dbPath, int status)
    {
        try
        {
            List<LabelShortForm> lsf = new List<LabelShortForm>();

            using (var connection = new SqliteConnection($"Data Source={dbPath};"))
            {
                connection.Open();
                string sqlSelect = @"SELECT Id,
                                            Fullpath,
                                            Status
                                       FROM Labels
                                      WHERE Status = @Status";

                using (var command = new SqliteCommand(sqlSelect, connection))
                {
                    command.Parameters.AddWithValue("@Status", status);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Retrieve data from the row
                            int Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            string Fullpath = reader.GetString(reader.GetOrdinal("Fullpath"));
                            int Status = reader.GetInt32(reader.GetOrdinal("Status"));

                            lsf.Add(new LabelShortForm(Id, Fullpath, Status));
                        }

                    }
                }
            }

            return lsf;
        }
        catch (Exception e)
        {
            Debug.WriteLine($"[DBAccess.GetLabels] {e.Message} {e.StackTrace}");
        }

        return null;
    }

    public static List<LabelShortForm> GetLabels(string dbPath, int[] status)
    {
        try
        {
            List<LabelShortForm> lsf = new List<LabelShortForm>();

            string instr = "(" + string.Join(',', status) + ")";

            using (var connection = new SqliteConnection($"Data Source={dbPath};"))
            {
                connection.Open();
                string sqlSelect = $"SELECT Id, Fullpath, Status FROM Labels WHERE Status IN {instr}";

                using (var command = new SqliteCommand(sqlSelect, connection))
                {
                    command.Parameters.AddWithValue("@Status", status);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Retrieve data from the row
                            int Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            string Fullpath = reader.GetString(reader.GetOrdinal("Fullpath"));
                            int Status = reader.GetInt32(reader.GetOrdinal("Status"));

                            lsf.Add(new LabelShortForm(Id, Fullpath, Status));
                        }

                    }
                }
            }

            return lsf;
        }
        catch (Exception e)
        {
            Debug.WriteLine($"[DBAccess.GetLabels] {e.Message} {e.StackTrace}");
        }

        return null;
    }
    public static int CheckUnique(string dbPath, string uniqueKey)
    {
        int id = -1;
        try
        {

            using (var connection = new SqliteConnection($"Data Source={dbPath};"))
            {
                connection.Open();
                string sqlSelect = @"SELECT Id
                                    FROM Labels
                                    WHERE Fullpath = @Fullpath";

                using (var command = new SqliteCommand(sqlSelect, connection))
                {
                    command.Parameters.AddWithValue("@Fullpath", uniqueKey);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieve data from the row
                            id = reader.GetInt32(reader.GetOrdinal("Id"));
                        }
                        //else
                        //{
                        //    Console.WriteLine($"No row found with Fullpath: {uniqueKey}");
                        //}
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine($"[DBAccess.CheckUnique] {e.Message} {e.StackTrace}");
        }

        return id;
    }

    public static (ECGMapping?, List<LabelInfo>?) GetRecord(string dbName, int id)
    {
        LabelDTO dto = DBAccess.GetById(dbName, id);
        if (dto == null) return (null, null);

        return (new ECGMapping(dto), dto.LabelList);
    }
}
