namespace DomainClasses.Entities.Cms
{
    public class Setting
    {
        #region Properties
        public virtual string Name { get; set; }
        public virtual string Type { get; set; }
        public virtual string Value { get; set; }
        /// <summary>
        /// gets or sets body of blog post's comment
        /// </summary>
        public virtual byte[] RowVersion { get; set; }
        #endregion

    }
}
