using System.Runtime.Serialization;
using Task.DB;

namespace Task.TestHelpers
{
    public class OrderDetailSerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var entity = (Order_Detail)obj;
            info.AddValue("OrderID", entity.OrderID);
            info.AddValue("ProductID", entity.ProductID);
            info.AddValue("UnitPrice", entity.UnitPrice);
            info.AddValue("Quantity", entity.Quantity);
            info.AddValue("Discount", entity.Discount);
            info.AddValue("Order", entity.Order);
            info.AddValue("Product", entity.Product);           
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var entity = (Order_Detail)obj;
            entity.OrderID = (int)info.GetValue("OrderID", typeof(int));
            entity.ProductID = (int)info.GetValue("ProductID", typeof(int));
            entity.UnitPrice = (decimal)info.GetValue("UnitPrice", typeof(decimal));
            entity.Quantity = (short)info.GetValue("Quantity", typeof(short));
            entity.Discount = (float)info.GetValue("Discount", typeof(float));
            entity.Order = (Order)info.GetValue("Order", typeof(Order));
            entity.Product = (Product)info.GetValue("Product", typeof(Product));
            return entity;
        }
    }
}
