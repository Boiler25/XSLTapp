<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

	<xsl:key name="group" match="item" use="@group"/>
	<xsl:template match="list">
		<groups>
			<xsl:apply-templates select="item[generate-id(.) = generate-id(key('group',@group))]">
				<xsl:sort select="@group"/>
			</xsl:apply-templates>
		</groups>
	</xsl:template>

	<xsl:template match="item">
		<group name="{@group}">
			<xsl:for-each select="key('group',@group)">
				<item name="{@name}"/>
			</xsl:for-each>
		</group>
	</xsl:template>

</xsl:stylesheet>