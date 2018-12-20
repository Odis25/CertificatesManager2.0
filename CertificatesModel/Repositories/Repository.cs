using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data;
using CertificatesModel.Interfaces;
using CertificatesModel.Components;

namespace CertificatesModel.Repositories
{
    public static class Repository
    {
        static string _connectionString;

        static Repository()
        {
            _connectionString = $"DataSource = {Settings.Instance.DataBasePath}";
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

        public static Certificates GetAllCertificatesFromDB(CertificateEventArgs pattern)
        {
            using (SqlCeConnection connection = new SqlCeConnection(_connectionString))
            {
                SqlCeCommand cmd = new SqlCeCommand();
                cmd.Connection = connection;

                var id = pattern.ID == null ? "" : $"ID = @ID";
                var year = pattern.Year == null ? "" : $"YEARS = @YEARS";
                var certificateNumber = pattern.CertificateNumber == null ? "" : $"CERTIFICATE_NUMBER = @CERTIFICATE_NUMBER";
                var registerNumber = pattern.RegisterNumber == null ? "" : $"REGISTER_NUMBER = @REGISTER_NUMBER";
                var verificationMethod = pattern.VerificationMethod == null ? "" : $"VERIFICATION_METHOD = @VERIFICATION_METHOD";
                var contractNumber = pattern.ContractNumber == null ? "" : $"CONTRACT_NUMBER = @CONTRACT_NUMBER";
                var clientName = pattern.ClientName == null ? "" : $"CLIENT_NAME = @CLIENT_NAME";
                var objectName = pattern.ObjectName == null ? "" : $"OBJECT_NAME = @OBJECT_NAME";
                var deviceType = pattern.DeviceType == null ? "" : $"TYPE_DEVICE = @TYPE_DEVICE";
                var deviceName = pattern.DeviceName == null ? "" : $"NAME_DEVICE = @NAME_DEVICE";
                var serialNumber = pattern.SerialNumber == null ? "" : $"SERIAL_NUMBER = @SERIAL_NUMBER";
                var calibDate = pattern.CalibrationDate == null ? "" : $"CALIB_DATE = @CALIB_DATE";
                var calibExpireDate = pattern.CalibrationExpireDate == null ? "" : $"CALIB_LAST_DATE = @CALIB_LAST_DATE";


                cmd.CommandText = $"SELECT * FROM METROLOGY WHERE ({id})";                    
                connection.Open();
            }

                return null;
        }

        private static Certificates ConstructDomainModel(List<Certificate> listOfCertificates)
        {                
            Certificates certificates = new Certificates();
            certificates.AddRange(listOfCertificates);

            return certificates; 
        }
    }
}
