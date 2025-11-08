namespace ProductFilterMvcApp.Models
{
    public class ColorSpecification : ISpecification<Product>
    {
        private Color _color;

        public ColorSpecification(Color color)
        {
            _color = color;
        }

        public bool IsSatisfied(Product p)
        {
            return p.Color == _color;
        }
    }
}
