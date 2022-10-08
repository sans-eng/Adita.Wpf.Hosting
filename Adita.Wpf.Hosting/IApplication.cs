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
using System;
using System.Windows;

namespace Adita.Wpf.Hosting
{
    /// <summary>
    /// Provides an abstraction for Windows Presentation Foundation <see cref="Application"/>.
    /// </summary>
    public interface IApplication
    {
        #region Properties
        /// <summary>
        /// Gets a <see cref="ServiceProvider"/> of current Windows Presentation Foundation application.
        /// </summary>
        IServiceProvider ServiceProvider { get; }
        /// <summary>
        /// Gets an <see cref="IConfiguration"/> of current Windows Presentation Foundation application.
        /// </summary>
        IConfiguration Configuration { get; }
        #endregion Properties

        #region methods
        /// <summary>
        /// Starts a Windows Presentation Foundation application.
        /// </summary>
        /// <returns>
        /// The <see cref="Int32"/> application exit code that is returned to the operating system when the application shuts down. By default, the exit code value is 0.
        /// </returns>
        int Run();
        /// <summary>
        /// Starts a Windows Presentation Foundation application and opens the specified <paramref name="window"/>.
        /// </summary>
        /// <param name="window"></param>
        /// <returns>
        /// The <see cref="Int32"/> application exit code that is returned to the operating system when the application shuts down. By default, the exit code value is 0.
        /// </returns>
        int Run(Window window);
        /// <summary>
        /// Shuts down an application.
        /// </summary>
        void Shutdown();
        /// <summary>
        /// Shuts down an application that returns the specified <paramref name="exitCode"/> to the operating system.
        /// </summary>
        /// <param name="exitCode">An integer exit code for an application. The default exit code is 0.</param>
        void Shutdown(int exitCode);
        /// <summary>
        /// Sets a <see cref="IServiceProvider"/> to current Windows Presentation Foundation application..
        /// </summary>
        /// <param name="serviceProvider">A <see cref="IServiceProvider"/> to set.</param>
        void SetServiceProvider(IServiceProvider serviceProvider);
        /// <summary>
        /// Sets an <see cref="IConfiguration"/> to current Windows Presentation Foundation application.
        /// </summary>
        /// <param name="configuration">An <see cref="IConfiguration"/> to set to.</param>
        void SetConfiguration(IConfiguration configuration);
        #endregion methods
    }
}
