using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


namespace JsonMinDatas
{
    public class Utils<Source,Destination>
        
    {
        static Expression<Func<Source, object>> CreateExpression(string propertyName)
        {
            var param = Expression.Parameter(typeof(Source), "x");
            Expression expr = Expression.PropertyOrField(param, propertyName);
            expr = Expression.Convert(expr, typeof(object));
            var ret= Expression.Lambda<Func<Source, object>>(expr, param);
            return ret;
        }
        static Func<Source, object> createFunc(string propName) 
        {
            return CreateExpression(propName).Compile();
        }
        public static void CreateMap(Dictionary<string, string> mapProperties)
        {
            var t=typeof(Source);
            var map=AutoMapper.Mapper.CreateMap<Source, Destination>();
            foreach (var item in mapProperties)
            {               
                if (string.IsNullOrEmpty(item.Value))
                {
                    map.ForMember(item.Key, config => config.Ignore());
                }
                else
                {
                    map.ForMember(item.Key, config => 
                        
                        //config.MapFrom(CreateExpression(item.Value))
                        config.ResolveUsing(
                        
                        createFunc(item.Value)));
                }
            }
            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
         
    }
}