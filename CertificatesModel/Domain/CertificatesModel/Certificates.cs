using CertificatesModel.Components;
using System.Collections.Generic;

namespace CertificatesModel
{
    public class Certificates : SortableBindingList<Certificate> //IEnumerable<Certificate>
    {
        public Certificates() :base()
        {
            
        }

        public Certificates(List<Certificate> list) : base(list)
        {

        }

        //protected List<Certificate> _list;

        //public Certificates()
        //{
        //    _list = new List<Certificate>();
        //}

        //public Certificates(List<Certificate> list)
        //{
        //    _list = list;
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}

        //public IEnumerator<Certificate> GetEnumerator()
        //{
        //    return _list.GetEnumerator();
        //}

        //// Преобразование из List<Certificate> к типу Certificates
        //public static explicit operator Certificates(List<Certificate> v)
        //{            
        //    return new Certificates(v);
        //}

        //// Удаление элемента
        //public void Remove(Certificate cert)
        //{
        //    _list.Remove(cert);
        //}

        //// Поиск элемента
        //public Certificate Find(Predicate<Certificate> p)
        //{
        //    return _list.Find(p);
        //}

        //// Добавление элемента
        //public void Add(Certificate item)
        //{
        //    _list.Add(item);
        //}

        //// Добавление коллекции элементов
        //public void AddRange(IEnumerable<Certificate> collection)
        //{
        //    _list.AddRange(collection);
        //}
    }

    //public class Certificates : List<Year>
    //{
    //    private List<Certificate> _certificates;
    //    private List<Contract> _contracts;

    //    /// <summary>
    //    /// Добавить список свидетельств
    //    /// </summary>
    //    /// <param name="certificates"></param>
    //    public void AddRange(IEnumerable<Certificate> certificates)
    //    {
    //        _certificates = certificates.ToList();

    //        _contracts = new List<Contract>();

    //        // Создаем и заполняем список годов
    //        var sortedYearsList = certificates.Select(x => x.Year).Distinct().OrderBy(x => x);

    //        foreach (var year in sortedYearsList)
    //        {
    //            Add(new Year() { YearOfCreationCertificate = year });
    //        }

    //        // Создаем и заполняем список договоров для каждого года
    //        foreach (Year year in this)
    //        {
    //            // Список Номеров договора конкретного года
    //            var contractsOfCurrentYear = certificates
    //                .Where(x => x.Year == year.YearOfCreationCertificate)
    //                .Select(x => x.ContractNumber)
    //                .Distinct()
    //                .OrderBy(x => x);

    //            foreach (var contract in contractsOfCurrentYear)
    //            {
    //                year.Add(new Contract() { ContractNumber = contract });
    //            }

    //            // Создаем и заполняем список свидетельств для каждого договора
    //            foreach (Contract contract in year)
    //            {
    //                contract.AddRange(certificates.Where(x => x.Year == year.YearOfCreationCertificate && x.ContractNumber == contract.ContractNumber));
    //            }

    //            _contracts.AddRange(year);
    //        }
    //    }

    //    // Преобразование List<Certificate> в Certificates
    //    public static explicit operator Certificates(List<Certificate> v)
    //    {
    //        var result = new Certificates();
    //        result.AddRange(v);
    //        return result;
    //    }

    //    /// <summary>
    //    /// Список договоров
    //    /// </summary>
    //    public List<Contract> ListOfContracts
    //    {
    //        get
    //        {
    //            return _contracts ?? new List<Contract>();
    //        }
    //    }

    //    /// <summary>
    //    /// Список свидетельств
    //    /// </summary>
    //    public List<Certificate> ListOfCertificates
    //    {
    //        get
    //        {
    //            return _certificates ?? new List<Certificate>();
    //        }
    //    }
    //}

}
