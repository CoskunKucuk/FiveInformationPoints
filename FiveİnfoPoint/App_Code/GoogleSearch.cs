//-*-*-*-*-*---Coşkun Küçük - Sakarya Üniversitesi Bilgisayar Mühendisliği
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleSearchEngine
{
   public class GoogleSearch
    {
        private const string apiKey = "AIzaSyCsDXD9ASkKILU9Ddd6ASQAEhFQKy6xtpk";
        private readonly string Query;
        public GoogleSearch(string _Query) { Query = _Query; }

        //--------------------------------------------------------------------------------------------------------------------------
        /// <summary>Google News Search
        /// <para>Work Google Search Engine Class and Search Data type </para>
        /// </summary>
        Search _newsSearch;
        private void _NewsSearch()
        {
            const string searchEngineId = "011018437923151163157:8ubuf0ji1ga";
            CustomsearchService customSearchService = new CustomsearchService(
                               new Google.Apis.Services.BaseClientService.Initializer() { ApiKey = apiKey });
            Google.Apis.Customsearch.v1.CseResource.ListRequest listRequest = customSearchService.Cse.List(Query);
            listRequest.Cx = searchEngineId;
            listRequest.Num = 10;
            Search search = listRequest.Execute();
            _newsSearch = search;
        }
        public Search NewsSearch()
        {
            _NewsSearch();
            return _newsSearch;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>Google Reddit Search
        /// <para> Work Google Search Engine Class and "Search" Data type</para>
        /// </summary>
        Search _redditSearch;
        private void _RedditSearch()
        {
            const string searchEngineId = "011018437923151163157:1nmspjcajja";
            CustomsearchService customSearchService = new CustomsearchService(new Google.Apis.Services.BaseClientService.Initializer() { ApiKey = apiKey });
            Google.Apis.Customsearch.v1.CseResource.ListRequest listRequest = customSearchService.Cse.List(Query);
            listRequest.Cx = searchEngineId;
            listRequest.Num = 10;
            Search search = listRequest.Execute();
            _redditSearch = search;
        }
        public Search RedditSearch()
        {
            _RedditSearch();
            return _redditSearch;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>Google GooglePlus Search
        /// <para> Work Google Search Engine Class and "Search" Data type</para>
        /// </summary>
        Search _googlePlusSearch;
        private void _GooglePlusSearch()
        {
            const string searchEngineId = "011018437923151163157:zuxxfb2fjrc";
            CustomsearchService customSearchService = new CustomsearchService(new Google.Apis.Services.BaseClientService.Initializer() { ApiKey = apiKey });
            Google.Apis.Customsearch.v1.CseResource.ListRequest listRequest = customSearchService.Cse.List(Query);
            listRequest.Cx = searchEngineId;
            listRequest.Num = 10;
            Search search = listRequest.Execute();
            _googlePlusSearch = search;
        }
        public Search GooglePlusSearch()
        {
            _GooglePlusSearch();
            return _googlePlusSearch;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>Google Linkedin Search
        /// <para>Work Google Search Engine Class and "Search" Data type </para>
        /// </summary>
        Search _linkedinSearch;
        private void _LinkedinSearch()
        {
            const string searchEngineId = "011018437923151163157:z3q1kr1lzg0";
            CustomsearchService customSearchService = new CustomsearchService(new Google.Apis.Services.BaseClientService.Initializer() { ApiKey = apiKey });
            Google.Apis.Customsearch.v1.CseResource.ListRequest listRequest = customSearchService.Cse.List(Query);
            listRequest.Cx = searchEngineId;
            listRequest.Num = 10;
            Search search = listRequest.Execute();
            _linkedinSearch = search;
        }
        public Search LinkedinSearch()
        {
            _LinkedinSearch();
            return _linkedinSearch;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>Google Facebook Search 
        /// <para>Work Google Search Engine Class and "Search" Data type</para>
        /// </summary>
        Search _facebookSearch;
        private void _FacebookSearch()
        {
            const string searchEngineId = "011018437923151163157:3sfk7w7zoha";
            CustomsearchService customSearchService = new CustomsearchService(new Google.Apis.Services.BaseClientService.Initializer() { ApiKey = apiKey });
            Google.Apis.Customsearch.v1.CseResource.ListRequest listRequest = customSearchService.Cse.List(Query);
            listRequest.Cx = searchEngineId;
            listRequest.Num = 10;
            Search search = listRequest.Execute();
            _facebookSearch = search;
        }
        public Search FacebookSearch()
        {
            _FacebookSearch();
            return _facebookSearch;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>Google Twitter Search 
        /// <para>Work Google Search Engine Class and "Search" Data type</para>
        /// </summary>
        Search _twitterSearch;
        private void _TwitterSearch()
        {
            const string searchEngineId = "011018437923151163157:3sfk7w7zoha";
            CustomsearchService customSearchService = new CustomsearchService(new Google.Apis.Services.BaseClientService.Initializer() { ApiKey = apiKey });
            Google.Apis.Customsearch.v1.CseResource.ListRequest listRequest = customSearchService.Cse.List(Query);
            listRequest.Cx = searchEngineId;
            listRequest.Num = 10;
            Search search = listRequest.Execute();
            _twitterSearch = search;
        }
        public Search TwitterSearch()
        {
            _TwitterSearch();
            return _twitterSearch;
        }


        Search _googleSearch;
        private void _GoogleSearch()
        {
            const string searchEngineId = "011018437923151163157:14aw4tqykpe";
            CustomsearchService customSearchService = new CustomsearchService(new Google.Apis.Services.BaseClientService.Initializer() { ApiKey = apiKey });
            Google.Apis.Customsearch.v1.CseResource.ListRequest listRequest = customSearchService.Cse.List(Query);
            listRequest.Cx = searchEngineId;
            listRequest.Num = 10;
            Search search = listRequest.Execute();
            _googleSearch = search;
        }
        public Search GoogleSearch_()
        {
            _GoogleSearch();
            return _googleSearch;
        }
    }
}
