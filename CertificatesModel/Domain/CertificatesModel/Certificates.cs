using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesModel
{

    public class Certificates : List<Year>
    {
        private List<Certificate> _certificates;
        private List<Contract> _contracts;

        /// <summary>
        /// Добавить список свидетельств
        /// </summary>
        /// <param name="certificates"></param>
        public void AddRange(IEnumerable<Certificate> certificates)
        {
            _certificates = certificates.ToList();

            _contracts = new List<Contract>();

            // Создаем и заполняем список годов
            var sortedYearsList = certificates.Select(x => x.Year).Distinct().OrderBy(x => x).ToList();

            sortedYearsList.ForEach((y) => { this.Add(new Year() { YearOfCreationCertificate = y }); });

            // Создаем и заполняем список договоров для каждого года
            foreach (Year year in this)
            {
                // Список Номеров договора конкретного года
                var contractsOfCurrentYear = certificates
                    .Where(x => x.Year == year.YearOfCreationCertificate)
                    .Select(x => x.ContractNumber)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToList();

                contractsOfCurrentYear.ForEach((c) => { year.Add(new Contract() { ContractNumber = c }); });

                // Создаем и заполняем список свидетельств для каждого договора
                foreach (Contract contract in year)
                {
                    contract.AddRange(certificates.Where(x => x.Year == year.YearOfCreationCertificate && x.ContractNumber == contract.ContractNumber));
                }

                _contracts.AddRange(year);
            }
        }

        // Преобразование List<Certificate> в Certificates
        public static explicit operator Certificates(List<Certificate> v)
        {
            var result = new Certificates();
            result.AddRange(v);
            return result;
        }

        /// <summary>
        /// Список договоров
        /// </summary>
        public List<Contract> ListOfContracts
        {
            get
            {
                return _contracts ?? new List<Contract>();
            }
        }

        /// <summary>
        /// Список свидетельств
        /// </summary>
        public List<Certificate> ListOfCertificates
        {
            get
            {
                return _certificates ?? new List<Certificate>();
            }
        }
    }
}
