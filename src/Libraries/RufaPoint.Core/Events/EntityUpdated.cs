﻿namespace RufaPoint.Core.Events
{
    /// <summary>
    /// A container for entities that are updated.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityUpdated<T> where T : BaseEntity
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="entity">Entity</param>
        public EntityUpdated(T entity)
        {
            Entity = entity;
        }

        /// <summary>
        /// Entity
        /// </summary>
        public T Entity { get; }
    }
}