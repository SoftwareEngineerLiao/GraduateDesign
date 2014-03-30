using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Commons;

namespace Model
{
    /// <summary>
    /// 实体类：NoticeEntity。
    ///</summary>
    [Serializable]
    public class NoticeEntity
    {
        #region 存储字段。
        private int _id;
        private string _title;
        private string _content;
        private string _type;
        private DateTime _time;
        #endregion

        #region 初始化 notice 类的新实例。
        /// <summary>
        /// 初始化 notice" /> 类的新实例。
        ///</summary>
        public NoticeEntity()
        {
            _id = 0;
            _title = string.Empty;
            _content = string.Empty;
            _type = string.Empty;
            _time = DateTime.MinValue;
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        #endregion

        #region 获取或设置
        ///<summary>
        ///获取或设置
        ///</summary>
        ///<value></value>
        public DateTime time
        {
            get { return _time; }
            set { _time = value; }
        }
        #endregion

    }
}


