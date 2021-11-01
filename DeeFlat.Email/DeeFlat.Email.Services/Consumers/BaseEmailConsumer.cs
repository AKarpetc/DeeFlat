using HandlebarsDotNet;

namespace DeeFlat.Email.Services.Consumers
{
    public class BaseEmailConsumer
    {
        /// <summary>
        /// Компилирует представление для тела письма и наполняет его данными
        /// </summary>
        /// <typeparam name="T">Тип модели для рендера</typeparam>
        /// <param name="eventMessage">Модель для рендера</param>
        /// <returns></returns>
        protected string Render<T>(T eventMessage)
        {
            return Render<T>(eventMessage, GetRelativeViewPath());
        }

        /// <summary>
        /// Компилирует представление для тела письма и наполняет его данными
        /// </summary>
        /// <typeparam name="T">Тип модели для рендера</typeparam>
        /// <param name="eventMessage">Модель для рендера</param>
        /// <param name="viewPath">Путь к представлению для рендера тела письма</param>
        /// <returns></returns>
        protected string Render<T>(T eventMessage, string viewPath)
        {
            var template = Handlebars.CompileView(viewPath);
            var message = template(eventMessage);
            return message;
        }

        /// <summary>
        /// Папка в которой хранятся шаблоны писем
        /// </summary>
        private const string TemplatesFolder = "Templates";

        /// <summary>
        /// Возвращает имя представления на основе обработчика
        /// </summary>
        /// <returns></returns>
        public string GetViewName()
        {
            return GetType().Name.Replace("Consumer", "");
        }

        /// <summary>
        /// Возвращает относительный путь до представления
        /// </summary>
        /// <returns></returns>
        public string GetRelativeViewPath()
        {
            return $"{TemplatesFolder}\\{GetViewName()}.html";
        }
    }
}
