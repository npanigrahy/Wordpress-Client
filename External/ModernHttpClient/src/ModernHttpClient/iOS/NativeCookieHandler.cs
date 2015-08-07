// The MIT License (MIT)
//
// Copyright (c) 2015 FPT Software
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System.Collections.Generic;
using System.Linq;
using System.Net;

#if UNIFIED
using Foundation;
#else
using MonoTouch.Foundation;
#endif

namespace ModernHttpClient
{
    public class NativeCookieHandler
    {
        public void SetCookies(IEnumerable<Cookie> cookies)
        {
            foreach (var v in cookies.Select(ToNativeCookie)) {
                NSHttpCookieStorage.SharedStorage.SetCookie(v);
            }
        }

        public List<Cookie> Cookies {
            get {
                return NSHttpCookieStorage.SharedStorage.Cookies
                    .Select(ToNetCookie)
                    .ToList();
            }
        }

        static NSHttpCookie ToNativeCookie(Cookie cookie)
        {
            return new NSHttpCookie(cookie);
        }

        static Cookie ToNetCookie(NSHttpCookie cookie)
        {
            var nc = new Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain);
            nc.Secure = cookie.IsSecure;

            return nc;
        }
    }
}
