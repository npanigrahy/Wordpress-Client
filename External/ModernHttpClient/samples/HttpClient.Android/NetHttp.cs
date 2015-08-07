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


using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace HttpClient.Android
{
	public class NetHttp
	{
		MainActivity ad;

		public NetHttp (MainActivity ad)
		{
			this.ad = ad;
		}

		public async Task HttpSample (HttpMessageHandler handler = null)
		{
			this.ad.Busy ();
			System.Net.Http.HttpClient client = (handler == null) ?
				new System.Net.Http.HttpClient () :
					new System.Net.Http.HttpClient (handler);
			var stream = await client.GetStreamAsync (MainActivity.WisdomUrl);
			this.ad.Done ();
			ad.RenderStream (stream);
		}
	}
}

