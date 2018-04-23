import Grid from 'material-ui/Grid';
import PropTypes from 'prop-types';
import React from 'react';
import Table, {
    TableBody,
    TableCell,
    TableHead,
    TableRow
} from 'material-ui/Table';
import { CFG_HTTP } from '../cfg/cfg_http';

import LinkInterface from '../interfaces/link';

const LinksTable = (props) => {
    const links = props.links.map((link) => {
        return (
            <TableRow key={link.id}>
                <TableCell>{link.longUrl}</TableCell>
                <TableCell><a href={CFG_HTTP.URL_SERVER + link.shortUrl} target="_blank">{link.shortUrl}</a></TableCell>
                <TableCell>{link.uniqueVisits}</TableCell>
            </TableRow>
        );
    });

    return (
        <Grid className="linksTable" container>
            <Grid item xs={12} md={8}>
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell>Link address</TableCell>
                            <TableCell>Short Url</TableCell>
                            <TableCell>Unique Visits</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {links}
                    </TableBody>
                </Table>
            </Grid>
        </Grid>
    );
};

LinksTable.propTypes = {
    stops: PropTypes.arrayOf(LinkInterface)
};

export default LinksTable;
