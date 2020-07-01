using System;
using AutoMapper;
using ShopiXamarin.Models;
using _ShopiXamarin.Data;
using System.Collections.Generic;

namespace ShopiXamarin.Utils
{
    /// <summary>
    /// AutoMapper configuration for ShopiXamarin
    /// </summary>
    public class AutoMapperConfiguration
    {
        /// <summary>
        /// Get configuration
        /// </summary>
        /// <returns>Mapper configuration action</returns>
        public Action<IMapperConfigurationExpression> GetConfiguration()
        {
            Action<IMapperConfigurationExpression> action = cfg =>
            {
                //authentication
                cfg.CreateMap<User, UserModel>();
                cfg.CreateMap<UserModel, User>();
            };
            return action;
        }

        /// <summary>
        /// Mapper
        /// </summary>
        public static IMapper Mapper
        {
            get
            {
                return _mapper;
            }
        }
        private static IMapper _mapper;

        /// <summary>
        /// Initialize mapper
        /// </summary>
        public static void Init()
        {
            var amc = new AutoMapperConfiguration();

            var _mapperConfiguration = new MapperConfiguration(amc.GetConfiguration());

            
            _mapper = _mapperConfiguration.CreateMapper();
        }
    }
}