using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Project1WebApp
{
    public class CustomBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var data = bindingContext.HttpContext.Request.Query;

            var result = data.TryGetValue("countries",out var value);
            if(result)
            {
                var array = value.ToString().Split('|');

                bindingContext.Result = ModelBindingResult.Success(array);

            }
            return Task.CompletedTask;
        }
    }
}
