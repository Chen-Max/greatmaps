﻿
namespace GMap.NET.MapProviders
{
   using System;

   /// <summary>
   /// GoogleChinaTerrainMap provider
   /// </summary>
   public class GoogleChinaTerrainMapProvider : GoogleMapProviderBase
   {
      public static readonly GoogleChinaTerrainMapProvider Instance;

      GoogleChinaTerrainMapProvider()
      {
      }

      static GoogleChinaTerrainMapProvider()
      {
         Instance = new GoogleChinaTerrainMapProvider();
      }

      public string Version = "t@127,r@156";

      #region GMapProvider Members

      readonly Guid id = new Guid("831EC3CC-B044-4097-B4B7-FC9D9F6D2CFC");
      public override Guid Id
      {
         get
         {
            return id;
         }
      }

      readonly string name = "GoogleChinaMap";
      public override string Name
      {
         get
         {
            return name;
         }
      }

      public override PureImage GetTileImage(GPoint pos, int zoom)
      {
         string url = MakeTileImageUrl(pos, zoom, Language);

         return GetTileImageUsingHttp(url);
      }

      #endregion

      string MakeTileImageUrl(GPoint pos, int zoom, string language)
      {
         string sec1 = string.Empty; // after &x=...
         string sec2 = string.Empty; // after &zoom=...
         GetSecureWords(pos, out sec1, out sec2);

         return string.Format(UrlFormat, UrlFormatServer, GetServerNum(pos, 4), UrlFormatRequest, Version, ChinaLanguage, pos.X, sec1, pos.Y, zoom, sec2, ServerChina);
      }

      static readonly string ChinaLanguage = "zh-CN";
      static readonly string UrlFormatServer = "mt";
      static readonly string UrlFormatRequest = "vt";
      static readonly string UrlFormat = "http://{0}{1}.{10}/{2}/lyrs={3}&hl={4}&gl=cn&x={5}{6}&y={7}&z={8}&s={9}";
   }
}