
namespace RufaPoint.Cmis.Infrastructure.Interfaces
{
    /// <summary>
    /// CMIS type mutability. Controls how child types of a parent type mey be created updated or deleted.
    /// </summary>
    public interface ICmisTypeMutability : ICmisExtensionData
    {
		/// <summary>
		/// Indicates whether new child types may be created with this type as the parent.
		/// </summary>
		/// <value><c>true</c> if new child types of the parent type may be created; otherwise, <c>false</c>.</value>
		bool? Create { get; }

		/// <summary>
		/// Indicates whether clients may make changes to this type per the constraints deﬁned in this speciﬁcation.
		/// </summary>
		/// <value><c>true</c> if new child types of the parent type may be updated; otherwise, <c>false</c>.</value>
		bool? Update { get; }

		/// <summary>
		/// Indicates whether clients may delete this type if there are no instances of it in the repository.
		/// </summary>
		/// <value><c>true</c> if new child types of the parent type may be deleted; otherwise, <c>false</c>.</value>
		bool? Delete { get; }
    }
}
