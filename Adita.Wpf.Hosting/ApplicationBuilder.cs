//MIT License

//Copyright (c) 2022 Adita

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace Adita.Wpf.Hosting
{
    /// <summary>
    /// Represents a builder for a Windows Presentation Foundation application.
    /// </summary>
    /// <typeparam name="TApp">A <see cref="Type"/> that encapsulating the Windows Presentation Foundation application.</typeparam>
    public sealed class ApplicationBuilder<TApp> : IApplicationBuilder<TApp>
        where TApp : Application, IApplication, new()
    {
        #region private fields
        private bool _isBuilt;
        #endregion private fields

        #region Public properties
        /// <inheritdoc/>
        public IServiceCollection Services { get; } = new ServiceCollection();
        /// <inheritdoc/>
        public IConfiguration Configuration { get; private set; } = default!;

        #endregion Public properties

        #region Public methods
        /// <summary>
        /// Builds a Windows Presentation Foundation application. This method can only be called once.
        /// </summary>
        /// <returns>A Windows Presentation Foundation application.</returns>
        /// <exception cref="InvalidOperationException">A Windows Presentation Foundation application has been built.</exception>
        public TApp Build()
        {
            if (_isBuilt)
            {
                throw new InvalidOperationException("A Windows Presentation Foundation application has been built.");
            }

            TApp app = new();

            app.SetConfiguration(Configuration);
            app.SetServiceProvider(Services.BuildServiceProvider());
            _isBuilt = true;
            return app;
        }
        /// <inheritdoc/>
        public IApplicationBuilder<TApp> ConfigureAppConfiguration(Action<IConfigurationBuilder> configureAction)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            configureAction.Invoke(builder);
            Configuration = builder.Build();
            return this;
        }
        /// <inheritdoc/>
        public IApplicationBuilder<TApp> ConfigureServices(Action<IServiceCollection> configureAction)
        {
            configureAction.Invoke(Services);
            return this;
        }
        #endregion Public methods
    }
}
