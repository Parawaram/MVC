using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Remail.BusinessLogic.Classes
{
	[Serializable]
	public class MailingListAddresses : ISerializable
	{
		public List<int> Addresses { get; set; }
		public List<int> CustomAddresses { get; set; }
		public Dictionary<int, DateTime> AddressDelayedDeliveryDates { get; set; }
		public Dictionary<int, DateTime> CustomAddressDelayedDeliveryDates { get; set; }

		public MailingListAddresses()
		{

		}

		public MailingListAddresses(List<int> addresses, List<int> customAddresses)
		{
			Addresses = addresses;
			CustomAddresses = customAddresses;
		}

		public MailingListAddresses(SerializationInfo info, StreamingContext ctxt)
		{
			Addresses = (List<int>)info.GetValue("Addresses", typeof(List<int>));
			CustomAddresses = (List<int>)info.GetValue("CustomAddresses", typeof(List<int>));
			AddressDelayedDeliveryDates = (Dictionary<int, DateTime>)info.GetValue("AddressDelayedDeliveryDates", typeof(Dictionary<int, DateTime>));
			CustomAddressDelayedDeliveryDates = (Dictionary<int, DateTime>)info.GetValue("AddressDelayedDeliveryDates", typeof(Dictionary<int, DateTime>));
		}

		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("Addresses", Addresses);
			info.AddValue("CustomAddresses", CustomAddresses);
			info.AddValue("AddressDelayedDeliveryDates", AddressDelayedDeliveryDates);
			info.AddValue("CustomAddressDelayedDeliveryDates", CustomAddressDelayedDeliveryDates);
		}
	}
}
