﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificatesView.Factories
{
    abstract public class BaseFactory
    {
        // Словарь для регистрации соответствий интерфейсов классам
        Dictionary<Type, Type> interfaceToClass = new Dictionary<Type, Type>();

        // Метод регистрирующий интерфейс за определенным классом
        public void Register<TInterface, TImplementation>()
        {
            interfaceToClass[typeof(TInterface)] = typeof(TImplementation);
        }

        // Создание экземпляра класса соответствующего указанному интерфейсу, и приведение его к виду указанного интерфейса
        public TInterface Create<TInterface> (params object[] arguments)
        {
            if (interfaceToClass.ContainsKey(typeof(TInterface)))
                return (TInterface)Activator.CreateInstance(interfaceToClass[typeof(TInterface)]);
            else
                return (TInterface)Activator.CreateInstance(typeof(TInterface));
        }
    }
}