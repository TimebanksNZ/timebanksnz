using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace TimebanksNZ
{
    /// <summary>
    /// Evil service locators for DI until Ninject or similar is implemented
    /// </summary>
    public static class DI
    {
        // Thread static so this can be mocked for any unit tests
        [ThreadStatic]
        private static IRepositoryFactory _repositoryFactory;
        public static  IRepositoryFactory RepositoryFactory
        {
            get
            {
                // Lazy instantiation of default class
                if (_repositoryFactory == null)
                {
                    _repositoryFactory = new RepositoryFactory();
                }
                return _repositoryFactory;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _repositoryFactory = value;
            }
        }
        public static IRepositoryFactory CurrentRepositoryFactory { get; set; }
    }

    // Example of how to use
    // DI.CurrentRepositoryFactory.CreateUserRepository().Insert(entity);
}