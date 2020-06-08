using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task.DB;
using Task.TestHelpers;
using System.Runtime.Serialization;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace Task
{
	[TestClass]
	public class SerializationSolutions
	{
		Northwind dbContext;

		[TestInitialize]
		public void Initialize()
		{
			dbContext = new Northwind();
		}

		[TestMethod]
		public void SerializationCallbacks()
		{
			//dbContext.Configuration.ProxyCreationEnabled = false;
			dbContext.Configuration.ProxyCreationEnabled = true;
			dbContext.Configuration.LazyLoadingEnabled = true;

			var tester = new XmlDataContractSerializerTester<IEnumerable<Category>>(new NetDataContractSerializer(), true);
			var categories = dbContext.Categories
				//.Include(b => b.Products).AsNoTracking()
				.ToList();

			var result = tester.SerializeAndDeserialize(categories);
		}

		[TestMethod]
		public void ISerializable()
		{
			dbContext.Configuration.ProxyCreationEnabled = false;

			var tester = new XmlDataContractSerializerTester<IEnumerable<Product>>(new NetDataContractSerializer(), true);
			var products = dbContext.Products
				.Include(b => b.Supplier).AsNoTracking()
				.Include(b => b.Category).AsNoTracking()
				.Include(b => b.Order_Details).AsNoTracking()
				.ToList();

			var result = tester.SerializeAndDeserialize(products);
		}


		[TestMethod]
		public void ISerializationSurrogate()
		{
			dbContext.Configuration.ProxyCreationEnabled = false;

			var serializer = new NetDataContractSerializer();
			var surrogateSelector = new SurrogateSelector();
			surrogateSelector.AddSurrogate(typeof(Order_Detail), new StreamingContext(StreamingContextStates.All), new OrderDetailSerializationSurrogate());
			serializer.SurrogateSelector = surrogateSelector;

			var tester = new XmlDataContractSerializerTester<IEnumerable<Order_Detail>>(serializer, true);
			
			
			var orderDetails = dbContext.Order_Details
				.Include(b => b.Order).AsNoTracking()
				.Include(b => b.Product).AsNoTracking()
				.ToList();

			var result = tester.SerializeAndDeserialize(orderDetails);
		}

		[TestMethod]
		public void IDataContractSurrogate()
		{
			dbContext.Configuration.ProxyCreationEnabled = true;
			dbContext.Configuration.LazyLoadingEnabled = true;

			
			var surrogateSelector = new OrderDataContractSurrogate();

			DataContractSerializerSettings sett = new DataContractSerializerSettings();
			sett.DataContractSurrogate = surrogateSelector;

			var serializer = new DataContractSerializer(typeof(IEnumerable<Order>), sett);

			var tester = new XmlDataContractSerializerTester<IEnumerable<Order>>(serializer, true);
			var orders = dbContext.Orders.ToList();

			var result = tester.SerializeAndDeserialize(orders);
		}
	}
}
