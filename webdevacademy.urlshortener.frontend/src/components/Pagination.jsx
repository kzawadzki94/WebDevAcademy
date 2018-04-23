import Button from 'material-ui/Button';
import Grid from 'material-ui/Grid';
import Icon from 'material-ui/Icon';
import KeyboardArrowLeft from 'material-ui-icons/KeyboardArrowLeft';
import KeyboardArrowRight from 'material-ui-icons/KeyboardArrowRight';
import Paper from 'material-ui/Paper';
import PropTypes from 'prop-types';
import React from 'react';
import Typography from 'material-ui/Typography';

class Pagination extends React.Component {
    handleNext = () => {
        this.props.onPageChange(this.props.currentPage + 1);
    };

    handleBack = () => {
        this.props.onPageChange(this.props.currentPage - 1);
    };

    handleFirstPage = () => {
        this.props.onPageChange(1);
    };

    handleLastPage = () => {
        this.props.onPageChange(this.props.pagesLimit);
    };

    render() {
        return (
            <div className="tablePagination">
                <Paper square
                    elevation={0}>
                    <Grid container
                        className='tablePagination-wrapper'>
                        <Grid item
                            container
                            sm={12}
                            md={8}
                            className='tablePagination-prev'>
                            <Grid item
                                xs={3}>
                                <Button size="small"
                                    onClick={this.handleFirstPage}
                                    disabled={this.props.currentPage === 1}>
                                    <Icon>first_page</Icon>
                                </Button>
                                <Button size="small"
                                    onClick={this.handleBack}
                                    disabled={this.props.currentPage === 1}>
                                    <KeyboardArrowLeft /> Back
                                </Button>
                            </Grid>
                            <Grid item
                                xs={6}
                                className='tablePagination-desc'>
                                <Typography>Page {this.props.currentPage} of {this.props.pagesLimit}</Typography>
                            </Grid>
                            <Grid item
                                xs={3}
                                className='tablePagination-next'>
                                <Button size="small"
                                    onClick={this.handleNext}
                                    disabled={this.props.currentPage === this.props.pagesLimit}>
                                    Next <KeyboardArrowRight />
                                </Button>
                                <Button size="small"
                                    onClick={this.handleLastPage}
                                    disabled={this.props.currentPage === this.props.pagesLimit}>
                                    <Icon>last_page</Icon>
                                </Button>
                            </Grid>
                        </Grid>
                    </Grid>
                </Paper>
            </div>
        );
    }
}

Pagination.propTypes = {
    onPageChange: PropTypes.func.isRequired,
    currentPage: PropTypes.number.isRequired,
    pagesLimit: PropTypes.number.isRequired,
};

export default Pagination;
