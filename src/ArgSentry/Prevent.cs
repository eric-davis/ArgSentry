﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ArgSentry
{
    /// <summary>
    /// This class is a utility that is to be used to help validate method arguments and prevent specific scenarios.
    /// </summary>
    public static class Prevent
    {
        #region Collections

        /// <summary>
        /// Ensures that all collection values are not less than or equal to a specified value.
        /// </summary>
        /// <typeparam name="TCollection">
        /// The collection type.
        /// </typeparam>
        /// <typeparam name="TValue">
        /// The collection item value type.
        /// </typeparam>
        /// <param name="arg">
        /// The argument expression.
        /// </param>
        /// <param name="mustBeGreaterThan">
        /// The "must be after" value.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// if any collection value is less than or equal to the specified value.
        /// </exception>
        public static void CollectionWithAnyValuesLessThanOrEqualTo<TCollection, TValue>(
            Expression<Func<TCollection>> arg,
            TValue mustBeGreaterThan) where TCollection : ICollection<TValue> where TValue : IComparable, IComparable<TValue>
        {
            var info = MemberInfo<TCollection>.GetMemberInfo(arg);
            CollectionWithAnyValuesLessThanOrEqualTo(info.MemberValue, mustBeGreaterThan, info.MemberName);
        }

        /// <summary>
        /// Ensures that all collection values are not less than or equal to a specified value.
        /// </summary>
        /// <typeparam name="TCollection">
        /// The collection type.
        /// </typeparam>
        /// <typeparam name="TValue">
        /// The collection item value type.
        /// </typeparam>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <param name="mustBeGreaterThan">
        /// The "must be after" value.
        /// </param>
        /// <param name="paramName">
        /// The parameter name.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// if any collection value is less than or equal to the specified value.
        /// </exception>
        public static void CollectionWithAnyValuesLessThanOrEqualTo<TCollection, TValue>(
            TCollection collection,
            TValue mustBeGreaterThan,
            string paramName) where TCollection : ICollection<TValue> where TValue : IComparable, IComparable<TValue>
        {
            if (collection == null)
            {
                return;
            }

            using (var enumerator = collection.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.CompareTo(mustBeGreaterThan) <= 0)
                    {
                        throw new ArgumentOutOfRangeException(
                                  paramName,
                                  $"All collection values must be greater than {mustBeGreaterThan}.");
                    }
                }
            }
        }

        /// <summary>
        /// Ensures that an enumerable argument is not null or empty.
        /// </summary>
        /// <param name="arg">
        /// The argument expression.
        /// </param>
        /// <typeparam name="TCollection">
        /// The argument type.
        /// </typeparam>
        /// <exception cref="ArgumentNullException">
        /// if the argument value is null or empty.
        /// </exception>
        public static void NullOrEmptyCollection<TCollection>(Expression<Func<TCollection>> arg)
            where TCollection : ICollection
        {
            var info = MemberInfo<TCollection>.GetMemberInfo(arg);
            NullOrEmptyCollection(info.MemberValue, info.MemberName);
        }

        /// <summary>
        /// Ensures that an enumerable argument is not null or empty.
        /// </summary>
        /// <param name="collection">
        /// The collection.
        /// </param>
        /// <param name="paramName">
        /// The parameter name.
        /// </param>
        /// <typeparam name="TCollection">
        /// The collection type.
        /// </typeparam>
        /// <exception cref="ArgumentNullException">
        /// if the argument value is null or empty.
        /// </exception>
        public static void NullOrEmptyCollection<TCollection>(TCollection collection, string paramName)
            where TCollection : ICollection
        {
            if (collection == null || collection.Count == 0)
            {
                throw new ArgumentException("Collection cannot be null or empty.", paramName);
            }
        }

        #endregion

        #region NullObject

        /// <summary>
        /// Ensures that an object is not null.
        /// </summary>
        /// <typeparam name="T">
        /// The argument type.
        /// </typeparam>
        /// <param name="arg">
        /// The argument expression.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// if argument value is null.
        /// </exception>
        public static void NullObject<T>(Expression<Func<T>> arg) where T : class
        {
            var info = MemberInfo<T>.GetMemberInfo(arg);
            NullObject(info.MemberValue, info.MemberName);
        }

        /// <summary>
        /// Ensures that an object is not null.
        /// </summary>
        /// <typeparam name="T">
        /// The argument type.
        /// </typeparam>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <param name="paramName">
        /// The parameter name.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// if argument value is null.
        /// </exception>
        public static void NullObject<T>(T obj, string paramName) where T : class
        {
            if (obj == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        #endregion

        #region Strings

        /// <summary>
        /// Ensures that a string is not null or empty.
        /// </summary>
        /// <param name="arg">
        /// The argument.
        /// </param>
        /// <exception cref="ArgumentException">
        /// if the string is null or empty.
        /// </exception>
        public static void NullOrEmptyString(Expression<Func<string>> arg)
        {
            var info = MemberInfo<string>.GetMemberInfo(arg);
            NullOrEmptyString(info.MemberValue, info.MemberName);
        }

        /// <summary>
        /// Ensures that a string is not null or empty.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="paramName">
        /// The parameter name.
        /// </param>
        /// <exception cref="ArgumentException">
        /// if the string is null or empty.
        /// </exception>
        public static void NullOrEmptyString(string value, string paramName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"Value cannot be null or empty.", paramName);
            }
        }

        /// <summary>
        /// Ensures that a string is not null or white space.
        /// </summary>
        /// <param name="arg">
        /// The argument expression.
        /// </param>
        /// <exception cref="ArgumentException">
        /// if the string is null or white space.
        /// </exception>
        public static void NullOrWhiteSpaceString(Expression<Func<string>> arg)
        {
            var info = MemberInfo<string>.GetMemberInfo(arg);
            NullOrWhiteSpaceString(info.MemberValue, info.MemberName);
        }

        /// <summary>
        /// Ensures that a string argument is not null or white space.
        /// </summary>
        /// <param name="value">
        /// The string value.
        /// </param>
        /// <param name="paramName">
        /// The parameter name.
        /// </param>
        /// <exception cref="ArgumentException">
        /// if argument value is null, empty, or white space.
        /// </exception>
        public static void NullOrWhiteSpaceString(string value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value cannot be null, empty, or white space.", paramName);
            }
        }

        #endregion

        #region GreaterThan & GreaterThanOrEqualTo

        /// <summary>
        /// Ensures that an argument value is not greater than a specified value.
        /// </summary>
        /// <typeparam name="T">
        /// The argument type.
        /// </typeparam>
        /// <param name="arg">
        /// The argument.
        /// </param>
        /// <param name="mustBeLessThanOrEqualTo">
        /// The value the argument value must be less than or equal to.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// if the value is greater than the mustBeLessThanOrEqualTo value.
        /// </exception>
        public static void ValueGreaterThan<T>(Expression<Func<T>> arg, T mustBeLessThanOrEqualTo)
            where T : struct, IComparable, IComparable<T>
        {
            var info = MemberInfo<T>.GetMemberInfo(arg);
            ValueGreaterThan(info.MemberValue, mustBeLessThanOrEqualTo, info.MemberName);
        }

        /// <summary>
        /// Ensures that an argument value is not greater than a specified value.
        /// </summary>
        /// <typeparam name="T">
        /// The argument type.
        /// </typeparam>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="mustBeLessThanOrEqualTo">
        /// The value the argument value must be less than or equal to.
        /// </param>
        /// <param name="paramName">
        /// The parameter name.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// if the value is greater than the mustBeLessThanOrEqualTo value.
        /// </exception>
        public static void ValueGreaterThan<T>(T value, T mustBeLessThanOrEqualTo, string paramName)
            where T : struct, IComparable, IComparable<T>
        {
            if (value.CompareTo(mustBeLessThanOrEqualTo) > 0)
            {
                throw new ArgumentOutOfRangeException(paramName, $"Value must be less than or equal to {mustBeLessThanOrEqualTo}.");
            }
        }

        /// <summary>
        /// Ensures that an argument value is not greater than or equal to a specified value.
        /// </summary>
        /// <typeparam name="T">
        /// The argument type.
        /// </typeparam>
        /// <param name="arg">
        /// The argument.
        /// </param>
        /// <param name="mustBeLessThan">
        /// The value the argument value must be less than.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// if the value is greater than or equal to the mustBeLessThan value.
        /// </exception>
        public static void ValueGreaterThanOrEqualTo<T>(Expression<Func<T>> arg, T mustBeLessThan)
            where T : struct, IComparable, IComparable<T>
        {
            var info = MemberInfo<T>.GetMemberInfo(arg);
            ValueGreaterThanOrEqualTo(info.MemberValue, mustBeLessThan, info.MemberName);
        }

        /// <summary>
        /// Ensures that an argument value is not greater than or equal to a specified value.
        /// </summary>
        /// <typeparam name="T">
        /// The argument type.
        /// </typeparam>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="mustBeLessThan">
        /// The value the argument value must be less than.
        /// </param>
        /// <param name="paramName">
        /// The parameter name.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// if the value is greater than or equal to the mustBeLessThan value.
        /// </exception>
        public static void ValueGreaterThanOrEqualTo<T>(T value, T mustBeLessThan, string paramName)
            where T : struct, IComparable, IComparable<T>
        {
            if (value.CompareTo(mustBeLessThan) >= 0)
            {
                throw new ArgumentOutOfRangeException(paramName, $"Value must be less than {mustBeLessThan}.");
            }
        }

        #endregion

        #region LessThan & LessThanOrEqualTo

        /// <summary>
        /// Ensures that an argument value is not less than a specified value.
        /// </summary>
        /// <typeparam name="T">
        /// The argument type.
        /// </typeparam>
        /// <param name="arg">
        /// The argument.
        /// </param>
        /// <param name="mustBeGreaterThanOrEqualTo">
        /// The value the argument value must be greater than or equal to.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// if the value is less than the mustBeGreaterThanOrEqualTo value.
        /// </exception>
        public static void ValueLessThan<T>(Expression<Func<T>> arg, T mustBeGreaterThanOrEqualTo)
            where T : struct, IComparable, IComparable<T>
        {
            var info = MemberInfo<T>.GetMemberInfo(arg);
            ValueLessThan(info.MemberValue, mustBeGreaterThanOrEqualTo, info.MemberName);
        }

        /// <summary>
        /// Ensures that an argument value is not less than a specified value.
        /// </summary>
        /// <typeparam name="T">
        /// The argument type.
        /// </typeparam>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="mustBeGreaterThanOrEqualTo">
        /// The value the argument value must be greater than or equal to.
        /// </param>
        /// <param name="paramName">
        /// The parameter name.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// if the value is less than the mustBeGreaterThanOrEqualTo value.
        /// </exception>
        public static void ValueLessThan<T>(T value, T mustBeGreaterThanOrEqualTo, string paramName)
            where T : struct, IComparable, IComparable<T>
        {
            if (value.CompareTo(mustBeGreaterThanOrEqualTo) < 0)
            {
                throw new ArgumentOutOfRangeException(paramName, $"Value must be greater than or equal to {mustBeGreaterThanOrEqualTo}.");
            }
        }

        /// <summary>
        /// Ensures that an argument value is not less than or equal to a specified value.
        /// </summary>
        /// <typeparam name="T">
        /// The argument type.
        /// </typeparam>
        /// <param name="arg">
        /// The argument.
        /// </param>
        /// <param name="mustBeGreaterThan">
        /// The value the argument value must be greater than.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// if argument value less than or equal to the mustBeGreaterThan value.
        /// </exception>
        public static void ValueLessThanOrEqualTo<T>(Expression<Func<T>> arg, T mustBeGreaterThan)
            where T : struct, IComparable, IComparable<T>
        {
            var info = MemberInfo<T>.GetMemberInfo(arg);
            ValueLessThanOrEqualTo(info.MemberValue, mustBeGreaterThan, info.MemberName);
        }

        /// <summary>
        /// Ensures that an argument value is not less than or equal to a specified value.
        /// </summary>
        /// <typeparam name="T">
        /// The argument type.
        /// </typeparam>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="mustBeGreaterThan">
        /// The value the argument value must be greater than.
        /// </param>
        /// <param name="paramName">
        /// The parameter name.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// if argument value less than or equal to the mustBeGreaterThan value.
        /// </exception>
        public static void ValueLessThanOrEqualTo<T>(T value, T mustBeGreaterThan, string paramName)
            where T : struct, IComparable, IComparable<T>
        {
            if (value.CompareTo(mustBeGreaterThan) <= 0)
            {
                throw new ArgumentOutOfRangeException(paramName, $"Value must be greater than {mustBeGreaterThan}");
            }
        }

        #endregion

        #region Ranges

        /// <summary>
        /// Ensures that an argument value is not outside the specified range.
        /// </summary>
        /// <typeparam name="T">
        /// The argument type.
        /// </typeparam>
        /// <param name="arg">
        /// The argument expression.
        /// </param>
        /// <param name="rangeStart">
        /// The range start.
        /// </param>
        /// <param name="rangeEnd">
        /// The range end.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// if value is outside the specified range.
        /// </exception>
        public static void ValueOutsideOfRange<T>(Expression<Func<T>> arg, T rangeStart, T rangeEnd)
            where T : IComparable, IComparable<T>
        {
            var info = MemberInfo<T>.GetMemberInfo(arg);
            ValueOutsideOfRange(info.MemberValue, rangeStart, rangeEnd, info.MemberName);
        }

        /// <summary>
        /// Ensures that an argument value is not outside the specified range.
        /// </summary>
        /// <typeparam name="T">
        /// The value type.
        /// </typeparam>
        /// <param name="value">
        /// The argument expression.
        /// </param>
        /// <param name="rangeStart">
        /// The range start.
        /// </param>
        /// <param name="rangeEnd">
        /// The range end.
        /// </param>
        /// <param name="paramName">
        /// The parameter name.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// if value is outside the specified range.
        /// </exception>
        public static void ValueOutsideOfRange<T>(T value, T rangeStart, T rangeEnd, string paramName)
            where T : IComparable, IComparable<T>
        {
            if (value.CompareTo(rangeStart) < 0 || value.CompareTo(rangeEnd) > 0)
            {
                throw new ArgumentOutOfRangeException(paramName, $"Value outside of specified range; {rangeStart} - {rangeEnd}.");
            }
        }

        #endregion

        #region Guids

        /// <summary>
        /// Ensures that a Guid value has been initialized.
        /// </summary>
        /// <param name="arg">
        /// The argument expression.
        /// </param>
        /// <exception cref="ArgumentException">
        /// if Guid value has not be initialized.
        /// </exception>
        public static void EmptyGuid(Expression<Func<Guid>> arg)
        {
            var info = MemberInfo<Guid>.GetMemberInfo(arg);
            EmptyGuid(info.MemberValue, info.MemberName);
        }

        /// <summary>
        /// Ensures that a Guid value has been initialized.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="paramName">
        /// The parameter name.
        /// </param>
        /// <exception cref="ArgumentException">
        /// if Guid value has not be initialized.
        /// </exception>
        public static void EmptyGuid(Guid value, string paramName)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentException("Value cannot be empty.", paramName);
            }
        }

        #endregion
    }
}
