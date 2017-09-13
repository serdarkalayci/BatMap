using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BatMap {

    public static class Mapper {
        private static readonly Lazy<MapConfiguration> _mapConfig = new Lazy<MapConfiguration>(() => new MapConfiguration(DynamicMapping.MapAndCache));
        private static MapConfiguration DefaultConfig => _mapConfig.Value;

        #region Register

        public static IMapDefinition RegisterMap(Type inType, Type outType, Action<MapBuilder> buildAction = null) {
            return DefaultConfig.RegisterMap(inType, outType);
        }

        public static IMapDefinition<TIn, TOut> RegisterMap<TIn, TOut>(Action<MapBuilder<TIn, TOut>> buildAction = null) {
            return DefaultConfig.RegisterMap(buildAction);
        }

        public static IMapDefinition<TIn, TOut> RegisterMap<TIn, TOut>(Expression<Func<TIn, MapContext, TOut>> expression) {
            return DefaultConfig.RegisterMap(expression);
        }

        #endregion

        #region Map

        public static TOut Map<TIn, TOut>(TIn inObj, bool? preserveReferences = null) {
            return DefaultConfig.Map<TIn, TOut>(inObj, preserveReferences);
        }

        public static TOut MapTo<TIn, TOut>(TIn inObj, TOut outObj, bool? preserveReferences = null) {
            return DefaultConfig.MapTo(inObj, outObj, preserveReferences);
        }

        public static TOut Map<TOut>(object inObj, bool? preserveReferences = null) {
            return DefaultConfig.Map<TOut>(inObj, preserveReferences);
        }

        public static object Map(object inObj, bool? preserveReferences = null) {
            return DefaultConfig.Map(inObj, preserveReferences);
        }

        public static object Map(object inObj, Type outType, bool? preserveReferences = null) {
            return DefaultConfig.Map(inObj, outType, preserveReferences);
        }

        public static IEnumerable<TOut> Map<TIn, TOut>(this IEnumerable<TIn> source, bool? preserveReferences = null) {
            return DefaultConfig.Map<TIn, TOut>(source, preserveReferences);
        }

        public static Dictionary<TOutKey, TOutValue> Map<TInKey, TInValue, TOutKey, TOutValue>(IDictionary<TInKey, TInValue> source, bool? preserveReferences = null) {
            return DefaultConfig.Map<TInKey, TInValue, TOutKey, TOutValue>(source, preserveReferences);
        }

        #endregion

        #region Projection

        public static IQueryable<TOut> ProjectTo<TOut>(this IQueryable query, bool checkIncludes = true) {
            return DefaultConfig.ProjectTo<TOut>(query, checkIncludes);
        }

        public static IQueryable<TOut> ProjectTo<TIn, TOut>(this IQueryable<TIn> query, params Expression<Func<TIn, object>>[] includes) {
            return DefaultConfig.ProjectTo<TIn, TOut>(query, includes);
        }

        public static IQueryable<TOut> ProjectTo<TOut>(this IQueryable query, params IncludePath[] includes) {
            return DefaultConfig.ProjectTo<TOut>(query, includes);
        }

        #endregion
    }
}
