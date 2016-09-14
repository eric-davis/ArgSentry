namespace ArgSentry
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// The member information.
    /// </summary>
    /// <typeparam name="T">
    /// The argument type.
    /// </typeparam>
    internal class MemberInfo<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberInfo{T}"/> class.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        private MemberInfo(Expression<Func<T>> expression)
        {
            var body = (MemberExpression)expression.Body;
            this.MemberName = body.Member.Name;
            this.MemberValue = expression.Compile()();
        }

        /// <summary>
        /// Gets the member name.
        /// </summary>
        public string MemberName { get; }

        /// <summary>
        /// Gets the member value.
        /// </summary>
        public T MemberValue { get; }

        /// <summary>
        /// The get member info.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <returns>
        /// The <see cref="MemberInfo{T}"/>.
        /// </returns>
        public static MemberInfo<T> GetMemberInfo(Expression<Func<T>> expression)
        {
            return new MemberInfo<T>(expression);
        }
    }
}
