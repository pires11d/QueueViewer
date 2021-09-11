using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Custom
{
    public class SyntaxRichTextBox : RichTextBox
	{
		private SyntaxSettings _settings = new SyntaxSettings();
		private static bool _bPaint = true;
		private string _strLine = "";
		private int _nContentLength = 0;
		private int _nLineLength = 0;
		private int _nLineStart = 0;
		private int _nLineEnd = 0;
		private string _strKeywords = "";
		private int _nCurSelection = 0;
        private string _json;


		/// <summary>
		/// The Json field.
		/// </summary>
		public string Json
        {
            get { return _json; }
            set 
			{ 
				_json = value;
				this.Text = _json;
				ProcessAllLines();
			}
        }

        /// <summary>
        /// The settings.
        /// </summary>
        public SyntaxSettings Settings
		{
			get { return _settings; }
		}
		
		/// <summary>
		/// WndProc
		/// </summary>
		/// <param name="m"></param>
		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
			if (m.Msg == 0x00f)
			{
				if (_bPaint)
					base.WndProc(ref m);
				else
					m.Result = IntPtr.Zero;
			}
			else
				base.WndProc(ref m);
		}
		/// <summary>
		/// OnTextChanged
		/// </summary>
		/// <param name="e"></param>
		protected override void OnTextChanged(EventArgs e)
		{
			// Calculate shit here.
			_nContentLength = this.TextLength;

			int nCurrentSelectionStart = SelectionStart;
			int nCurrentSelectionLength = SelectionLength;

			_bPaint = false;

			// Find the start of the current line.
			_nLineStart = nCurrentSelectionStart;
			while ((_nLineStart > 0) && (Text[_nLineStart - 1] != '\n'))
				_nLineStart--;
			// Find the end of the current line.
			_nLineEnd = nCurrentSelectionStart;
			while ((_nLineEnd < Text.Length) && (Text[_nLineEnd] != '\n'))
				_nLineEnd++;
			// Calculate the length of the line.
			_nLineLength = _nLineEnd - _nLineStart;
			// Get the current line.
			_strLine = Text.Substring(_nLineStart, _nLineLength);

			// Process this line.
			ProcessLine();

			_bPaint = true;
		}
		/// <summary>
		/// Process a line.
		/// </summary>
		private void ProcessLine()
		{
			// Save the position and make the whole line black
			int nPosition = SelectionStart;
			SelectionStart = _nLineStart;
			SelectionLength = _nLineLength;
			SelectionColor = Color.Black;

			// Process the keywords
			ProcessRegex(_strKeywords, Settings.KeywordColor);
			// Process numbers
			if(Settings.EnableIntegers)
				ProcessRegex("\\b(?:[0-9]*\\.)?[0-9]+\\b", Settings.IntegerColor);
			// Process strings
			if(Settings.EnableStrings)
				ProcessRegex("\"[^\"\\\\\\r\\n]*(?:\\\\.[^\"\\\\\\r\\n]*)*\"", Settings.StringColor);
			// Process comments
			if(Settings.EnableComments && !string.IsNullOrEmpty(Settings.Comment))
				ProcessRegex(Settings.Comment + ".*$", Settings.CommentColor);

			SelectionStart = nPosition;
			SelectionLength = 0;
			SelectionColor = Color.Black;

			_nCurSelection = nPosition;
		}
		/// <summary>
		/// Process a regular expression.
		/// </summary>
		/// <param name="strRegex">The regular expression.</param>
		/// <param name="color">The color.</param>
		private void ProcessRegex(string strRegex, Color color)
		{
			Regex regKeywords = new Regex(strRegex, RegexOptions.IgnoreCase | RegexOptions.Compiled);
			Match regMatch;

			for (regMatch = regKeywords.Match(_strLine); regMatch.Success; regMatch = regMatch.NextMatch())
			{
				// Process the words
				int nStart = _nLineStart + regMatch.Index;
				int nLenght = regMatch.Length;
				SelectionStart = nStart;
				SelectionLength = nLenght;
				SelectionColor = color;
			}
		}
		/// <summary>
		/// Compiles the keywords as a regular expression.
		/// </summary>
		public void CompileKeywords()
		{
			for (int i = 0; i < Settings.Keywords.Count; i++)
			{
				string strKeyword = Settings.Keywords[i];

				if (i == Settings.Keywords.Count-1)
					_strKeywords += "\\b" + strKeyword + "\\b";
				else
					_strKeywords += "\\b" + strKeyword + "\\b|";
			}
		}

		public void ProcessAllLines()
		{
			_bPaint = false;

			int nStartPos = 0;
			int i = 0;
			int nOriginalPos = SelectionStart;
			while (i < Lines.Length)
			{
				_strLine = Lines[i];
				_nLineStart = nStartPos;
				_nLineEnd = _nLineStart + _strLine.Length;

				ProcessLine();
				i++;

				nStartPos += _strLine.Length+1;
			}

			_bPaint = true;
		}
	}

	/// <summary>
	/// Class to store syntax objects in.
	/// </summary>
	public class SyntaxList
	{
		public List<string> m_rgList = new List<string>();
		public Color m_color = new Color();
	}

	/// <summary>
	/// Settings for the keywords and colors.
	/// </summary>
	public class SyntaxSettings
	{
		SyntaxList m_rgKeywords = new SyntaxList();
		string m_strComment = "";
		Color m_colorComment = Color.Green;
		Color m_colorString = Color.Gray;
		Color m_colorInteger = Color.Red;
		bool m_bEnableComments = true;
		bool m_bEnableIntegers = true;
		bool m_bEnableStrings = true;

		#region Properties
		/// <summary>
		/// A list containing all keywords.
		/// </summary>
		public List<string> Keywords
		{
			get { return m_rgKeywords.m_rgList; }
		}
		/// <summary>
		/// The color of keywords.
		/// </summary>
		public Color KeywordColor
		{
			get { return m_rgKeywords.m_color; }
			set { m_rgKeywords.m_color = value; }
		}
		/// <summary>
		/// A string containing the comment identifier.
		/// </summary>
		public string Comment
		{
			get { return m_strComment; }
			set { m_strComment = value; }
		}
		/// <summary>
		/// The color of comments.
		/// </summary>
		public Color CommentColor
		{
			get { return m_colorComment; }
			set { m_colorComment = value; }
		}
		/// <summary>
		/// Enables processing of comments if set to true.
		/// </summary>
		public bool EnableComments
		{
			get { return m_bEnableComments; }
			set { m_bEnableComments = value; }
		}
		/// <summary>
		/// Enables processing of integers if set to true.
		/// </summary>
		public bool EnableIntegers
		{
			get { return m_bEnableIntegers; }
			set { m_bEnableIntegers = value; }
		}
		/// <summary>
		/// Enables processing of strings if set to true.
		/// </summary>
		public bool EnableStrings
		{
			get { return m_bEnableStrings; }
			set { m_bEnableStrings = value; }
		}
		/// <summary>
		/// The color of strings.
		/// </summary>
		public Color StringColor
		{
			get { return m_colorString; }
			set { m_colorString = value; }
		}
		/// <summary>
		/// The color of integers.
		/// </summary>
		public Color IntegerColor
		{
			get { return m_colorInteger; }
			set { m_colorInteger = value; }
		}
		#endregion
	}

	public static class Formatting
    {
		public static void Initialize(this SyntaxRichTextBox control)
		{
			// Add the keywords to the list.
			control.Settings.Keywords.Add("function");
			control.Settings.Keywords.Add("if");
			control.Settings.Keywords.Add("then");
			control.Settings.Keywords.Add("else");
			control.Settings.Keywords.Add("elseif");
			control.Settings.Keywords.Add("end");
			control.Settings.Keywords.Add("false");
			control.Settings.Keywords.Add("true");
			control.Settings.Keywords.Add("null");

			// Set the comment identifier. 
			// For Lua this is two minus-signs after each other (--).
			// For C++ code we would set this property to "//".
			control.Settings.Comment = "//";

			// Set the colors that will be used.
			control.Settings.KeywordColor = Color.Blue;
			control.Settings.CommentColor = Color.Gray;
			control.Settings.StringColor = Color.DarkRed;
			control.Settings.IntegerColor = Color.DarkGoldenrod;

			// Let's not process strings and integers.
			control.Settings.EnableStrings = true;
			control.Settings.EnableIntegers = true;

			// Let's make the settings we just set valid by compiling
			// the keywords to a regular expression.
			control.CompileKeywords();
		}
	}
}
