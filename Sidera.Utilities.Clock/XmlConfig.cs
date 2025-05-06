using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Sidera.Utilities.Clock
{
    internal class XmlConfig
    {
        #region Initialization
        #region Private flags
        private XmlDocument _xdoc;
        private string _filename;
        private bool _autosave;

        private string _xmlRoot;
        #endregion

        #region Constructors
        public XmlConfig(string filename, string root) : this(filename, root, true) { }

        public XmlConfig(string filename, string root, bool autosave)
        {
            _xdoc = new XmlDocument();
            _filename = filename;
            _autosave = autosave;

            _xmlRoot = root;

            //

            try
            {
                InitializeDocument();
            }
            catch (XmlException)
            {
                //Application.Restart();
            }

            FileInfo fiXml = new FileInfo(filename);

            _xdoc.Load(fiXml.FullName);
        }
        #endregion
        #endregion

        #region Public properties
        public string Filename
        {
            get { return _filename; }
        }

        public bool AutoSave
        {
            get { return _autosave; }
            set { _autosave = value; }
        }
        #endregion

        #region XML node object getters
        public XmlNode GetNode(string xpath)
        {
            XmlNode node = GetNode(xpath, 0);
            return node;
        }

        public XmlNode GetNode(string xpath, int index)
        {
            XmlNode[] nodes = GetNodes(xpath);
            return index < nodes.Length ? nodes[index] : null;
        }

        public XmlNode[] GetNodes(string xpath)
        {
            XmlNodeList nodeList = _xdoc.SelectNodes($"/{string.Join("/", _xmlRoot, xpath)}");
            XmlNode[] nodes = new XmlNode[nodeList.Count];
            for (int i = 0; i < nodeList.Count; i++)
            {
                nodes[i] = nodeList[i];
            }

            return nodes;
        }
        #endregion

        #region Getters
        #region XML attributes

        public string GetAttribute(string xpath, string attributeName)
        {
            return GetAttribute(xpath, 0, attributeName);
        }

        public string GetAttribute(string xpath, int index, string attributeName)
        {
            try
            {
                XmlNode node = GetNode(xpath, index);
                return node.Attributes[attributeName].Value;
            }
            catch
            {
                return null;
            }
        }
        #endregion
        #endregion

        #region Setters
        #region XML nodes

        private XmlNode CreateNode(string xpath)
        {
            // Eliminate requirement for XML root
            xpath = string.Concat("/", xpath.Trim('/'));

            //

            // Get all levels of the XPath and select the node at that XPATH
            string[] xlevels = xpath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            XmlNode xnode = _xdoc.SelectSingleNode($"/{string.Join("/", _xmlRoot, string.Join("/", xlevels))}");

            // If the node at the XPath does not exist:
            if (xnode == null)
            {
                // Get the document root node and traverse down the tree
                XmlNode xparent = _xdoc.DocumentElement;
                for (int level = 0; level < xlevels.Length; level++)
                {
                    // Get the name of the node at the current level in the XPath
                    string xname = xlevels[level];
                    if (!string.IsNullOrWhiteSpace(xname))
                    {
                        // Get the child node with the level name
                        XmlNode xchild = xparent.SelectSingleNode(xname);

                        // If the child node does not exist, traverse down
                        // the tree
                        if (xchild != null)
                        {
                            xparent = xchild;
                        }
                        else
                        {
                            XmlElement xnew = _xdoc.CreateElement(xname);
                            xparent.AppendChild(xnew);
                            xparent = xnew;
                        }
                    }
                }

                xnode = _xdoc.SelectSingleNode($"/{string.Join("/", _xmlRoot, string.Join("/", xlevels))}");
            }

            return xnode;
        }
        #endregion

        #region XML attributes

        public void SetAttribute(string xpath, string attributeName, string attributeValue)
        {
            SetAttribute(xpath, 0, attributeName, attributeValue);
        }

        public void SetAttribute(string xpath, int index, string attributeName, string attributeValue)
        {
            XmlNode node = GetNode(xpath, index);
            if (node == null)
            {
                node = CreateNode(xpath);
            }

            if (attributeValue != null)
            {
                ((XmlElement)node).SetAttribute(attributeName, attributeValue);
            }
            else
            {
                ((XmlElement)node).Attributes.RemoveNamedItem(attributeName);
            }

            //

            if (_autosave)
            {
                Save();
            }
        }
        #endregion

        #region XML inner values

        public void SetInnerText(string xpath, string innerText)
        {
            SetInnerText(xpath, 0, innerText);
        }

        public void SetInnerText(string xpath, int index, string innerText)
        {
            XmlNode node = GetNode(xpath, index);
            if (node == null)
            {
                node = CreateNode(xpath);
            }

            node.InnerText = innerText;

            //

            if (_autosave)
            {
                Save();
            }
        }

        public void SetInnerXml(string xpath, string innerXml)
        {
            SetInnerXml(xpath, 0, innerXml);
        }

        public void SetInnerXml(string xpath, int index, string innerXml)
        {
            XmlNode node = GetNode(xpath, index);
            if (node == null)
            {
                node = CreateNode(xpath);
            }

            node.InnerXml = innerXml;

            //

            if (_autosave)
            {
                Save();
            }
        }
        #endregion
        #endregion

        #region Deleters
        #region XML nodes
        public void DeleteNode(string xpath)
        {
            XmlNode node = GetNode(xpath);
            if (node != null)
                node.ParentNode.RemoveChild(node);

            //

            if (_autosave)
                Save();
        }

        public void DeleteNode(string xpath, int index)
        {
            XmlNode node = GetNode(xpath, index);
            if (node != null)
                node.ParentNode.RemoveChild(node);

            //

            if (_autosave)
                Save();
        }

        public void DeleteNodes(string xpath)
        {
            XmlNode[] nodes = GetNodes(xpath);
            foreach (XmlNode node in nodes)
                node.RemoveChild(node);

            //

            if (_autosave)
                Save();
        }
        #endregion

        #region XML inner values
        public void DeleteInnerText(string xpath)
        {
            SetInnerText(xpath, null);
        }

        public void DeleteInnerText(string xpath, int index)
        {
            SetInnerText(xpath, index, null);
        }

        public void DeleteInnerXml(string xpath)
        {
            SetInnerXml(xpath, null);
        }

        public void DeleteInnerXml(string xpath, int index)
        {
            SetInnerXml(xpath, index, null);
        }
        #endregion

        #region XML attributes
        public void DeleteAttribute(string xpath, string attributeName)
        {
            XmlNode node = GetNode(xpath);
            XmlAttribute attribute = node.Attributes[attributeName];
            node.Attributes.Remove(attribute);

            //

            if (_autosave)
                Save();
        }

        public void DeleteAttribute(string xpath, int index, string attributeName)
        {
            XmlNode node = GetNode(xpath, index);
            XmlAttribute attribute = node.Attributes[attributeName];
            node.Attributes.Remove(attribute);

            //

            if (_autosave)
                Save();
        }
        #endregion
        #endregion

        #region Miscellaneous
        public void InitializeDocument()
        {
            FileInfo fiConfig = new FileInfo(_filename);
            if (!fiConfig.Exists)
            {
                using (StreamWriter sw = new StreamWriter(_filename, false))
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(sw))
                    {
                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement(_xmlRoot);
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndDocument();
                    }
                }

                Save();
            }
        }

        public void Save()
        {
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            _xdoc.DocumentElement.SetAttribute("version", version);

            _xdoc.Save(_filename);
        }
        #endregion
    }
}
