<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<xsl:variable name="error">Error</xsl:variable>
<xsl:variable name="warning">Warning</xsl:variable>
<xsl:variable name="true">TRUE</xsl:variable>
<xsl:variable name="false">FALSE</xsl:variable>
<xsl:variable name="smallcase" select="'abcdefghijklmnopqrstuvwxyz'" />
<xsl:variable name="uppercase" select="'ABCDEFGHIJKLMNOPQRSTUVWXYZ'" />
<html>
	<head>
	<style>
	table{
		border-collapse:collapse;
	}
	table,th, td{
		border: 1px solid #aabbcc;
		padding: 3px 5px 3px 5px
	}
	table.pk{
		border-style: solid;
	}
	table.pk thead td{
		color: blue;
		font-family: 微軟正黑體;
		font-weight: bold;
	}
	table.field thead td{
		color: blue;
		font-family: 微軟正黑體;
		font-weight: bold;
	}
	table.pk tbody td, table.field tbody td{
		font-family: 微軟正黑體;
	}
	span.error{
		color: red;
	}
	span.warning{
		color: orange;
	}
	span.false{
		color: #789
	}
	</style>
	</head>
	<body>
		<table class="pk">
			<thead>
				<tr>
					<td>主鍵名稱</td>
					<td>欄位</td>
				</tr>
			</thead>
			<xsl:for-each select="ValidateRule/DuplicateDetection/Detector">
			<tbody>
				<tr>
					<td><xsl:value-of select="@Name" /></td>
					<td>
					<xsl:for-each select="Field">
						<xsl:value-of select="@Name" />,
					</xsl:for-each>
					</td>
				</tr>
			</tbody>
			</xsl:for-each>
		</table>
		<p/>
		<table class="field" border="1">
			<thead>
				<tr>
					<td>欄位名稱</td>
					<td>必要欄位</td>
					<td>是否允許內容空白</td>
					<td>驗證訊息</td>
					<td>欄位說明</td>
				</tr>
			</thead>
			<xsl:for-each select="ValidateRule/FieldList/Field">
			<tbody>
				<tr>
					<td><xsl:value-of select="@Name" /></td>

					<td>
						<xsl:choose>
							<xsl:when test="translate(@Required, $smallcase, $uppercase) = $true">
								<span class="true">必要</span>
							</xsl:when>
							<xsl:otherwise>
								<span class="false"></span>
							</xsl:otherwise>
						</xsl:choose>
					</td>
					<td>
						<xsl:choose>
							<xsl:when test="translate(@EmptyAlsoValidate, $smallcase, $uppercase) = $false">
								<span class="false">是</span>
							</xsl:when>
							<xsl:otherwise>
								<span class="true">否</span>
							</xsl:otherwise>
						</xsl:choose>
					</td>
					<td>
					<xsl:for-each select="Validate">

						<xsl:if test="@ErrorType = $error">
							<span class="error">錯誤：</span>
						</xsl:if>
						<xsl:if test="@ErrorType = $warning">
							<span class="warning">警告：</span>
						</xsl:if>
						<xsl:value-of select="@Description" /><br/>
					</xsl:for-each>
					</td>
					<td>
						<xsl:value-of disable-output-escaping="yes" select="@Description" />
					</td>
				</tr>
			</tbody>
			</xsl:for-each>
		</table>
	</body>
</html>

</xsl:template>
</xsl:stylesheet>