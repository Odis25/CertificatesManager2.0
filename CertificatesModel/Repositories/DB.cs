using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data;

namespace CertificatesModel.Repositories
{
    public class DB
    {
        Certificates _certificates;
        string _connectionString;

        public DB()
        {
            _connectionString = "DataSource = D:\\test.sdf";
        }

        public Certificates LoadDataFromDB()
        {
            using (SqlCeConnection connection = new SqlCeConnection(_connectionString))
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = "SELECT * FROM METROLOGY";
                _certificates = new Certificates();
                using (SqlCeDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        foreach (var years in _certificates)
                            foreach (var contracts in years)
                                foreach (var certificate in contracts)
                                {
                                    certificate.ID = reader.GetInt32(0);
                                    certificate.Year = reader.GetInt32(1);
                                    certificate.ContractNumber = reader.GetString(2);
                                    certificate.ClientName = reader.GetString(3);
                                    certificate.ObjectName = reader.GetString(4);
                                    certificate.DeviceType = reader.GetString(5);
                                    certificate.DeviceName = reader.GetString(6);
                                    certificate.SerialNumber = reader.GetString(7);
                                    certificate.CalibrationDate = reader.GetDateTime(8);
                                    certificate.CalibrationExpireDate = reader.GetDateTime(9);
                                    certificate.CertificatePath = reader.GetString(10);
                                }
                    }

                    return _certificates;
                }
            }
                
            
        }

    }
}
