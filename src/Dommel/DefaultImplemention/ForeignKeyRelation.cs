namespace Dommel
{
    public enum ForeignKeyRelation
    {
        /// <summary>
        /// Specifies a one-to-one relationship.
        /// </summary>
        OneToOne,

        /// <summary>
        /// Specifies a one-to-many relationship.
        /// </summary>
        OneToMany,

        /// <summary>
        /// Specifies a many-to-many relationship.
        /// </summary>
        ManyToMany
    }
}
