using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data;
using CertificatesModel.Interfaces;

namespace CertificatesModel.Repositories
{
    public static class Repository
    {
        static string _connectionString;

        static Repository()
        {
            _connectionString = "DataSource = D:\\test.sdf";
        }

        // Получаем все свидетельства из БД
        public static Certificates GetAllCertificatesFromDB()
        {
            using (SqlCeConnection connection = new SqlCeConnection(_connectionString))
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.CommandText = "SELECT * FROM METROLOGY";
                cmd.Connection = connection;
                connection.Open();
                using (SqlCeDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    List<Certificate> certificates = new List<Certificate>();
                    while (reader.Read())
                    {
                        certificates.Add(new Certificate()
                        {
                            ID = reader.GetInt32(0),
                            Year = reader.GetInt32(1),
                            ContractNumber = reader.GetString(2),
                            ClientName = reader.GetString(3),
                            ObjectName = reader.GetString(4),
                            DeviceType = reader.GetString(5),
                            DeviceName = reader.GetString(6),
                            SerialNumber = reader.GetString(7),
                            CalibrationDate = reader.GetDateTime(8),
                            CalibrationExpireDate = reader.GetDateTime(9),
                            CertificatePath = reader.GetString(10),
                            CertificateNumber = reader.GetValue(11).ToString(),
                            RegisterNumber = reader.GetValue(12).ToString(),
                            VerificationMethod = reader.GetValue(13).ToString()
                        });
                    }

                    return ConstructDomainModel(certificates);
                }
            }
        }

        private static Certificates ConstructDomainModel(List<Certificate> listOfCertificates)
        {                
            Certificates certificates = new Certificates();
            certificates.AddRange(listOfCertificates);

            return certificates; 
        }
    }
}
