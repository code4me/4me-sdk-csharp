using Newtonsoft.Json;

namespace Sdk4me
{
	/// <summary>
	/// A 4me <see href="https://developer.4me.com/v1/requests/watches/">Request Watch</see> object.
	/// </summary>
	public class RequestWatch : BaseItem
	{
		private Person addedBy;
		private Person person;

		#region Added by

		/// <summary>
		/// The person who created the watch.
		/// </summary>
		[JsonProperty("added_by")]
		public Person AddedBy
		{
			get => addedBy;
			internal set => addedBy = value;
		}

		[JsonProperty("added_by_id"), Sdk4meIgnoreInFieldSelection()]
		internal long? AddedByID => addedBy?.ID;

		#endregion

		#region Person

		/// <summary>
		/// The person who is selected as the watcher.
		/// </summary>
		[JsonProperty("person")]
		public Person Person
		{
			get => person;
			set => person = SetValue("person_id", person, value);
		}

		[JsonProperty("person_id"), Sdk4meIgnoreInFieldSelection()]
		internal long? PersonID => person?.ID;

		#endregion
	}
}